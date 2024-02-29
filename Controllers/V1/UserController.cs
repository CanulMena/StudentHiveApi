using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1
{
    //* These are the entry and exit point
    //*Here i begin to work with my DTO and mappers. 
// to do commit
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly UsersService _usersService;
        public readonly IMapper _mapper;
        public readonly ImageUploadService _imageUploadService;

        public UserController( UsersService usersService, IMapper mapper, ImageUploadService imageUploadService )
        {
            this._usersService = usersService;
            this._mapper = mapper;
            this._imageUploadService = imageUploadService;
        }

        [Authorize(Policy = "Administrador")] // --> Me esta pidiendo la autorizacion del tipo de rol
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Users = await _usersService.GetAll();
            var UserDtos = _mapper.Map<IEnumerable<UserDTO>>(Users);
            return Ok( UserDtos );
        }

        [Authorize(Policy = "Usuario")]
        [HttpGet("id/{id}")] //? <--- this is the form that we will watch the Url.
        public async Task<IActionResult> GetById(int id) 
        {
            var User = await _usersService.GetById(id); 
            if( User.IdUser <= 0 ) 
            return NotFound();

            var UserToUserDto = _mapper.Map<UserDTO>(User);

            return Ok( UserToUserDto );
        }

        [Authorize(Policy = "Usuario")]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _usersService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            var UserToUserDto = _mapper.Map<UserDTO>(user);
            return Ok(UserToUserDto);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> AuthLogin(AuthLoginDTO authLogin)
        {   //me esta regresando la instancia del usuario que existe en la base de datos con el campo de rol
            var userToken = await _usersService.AuthLogin(authLogin);
            //* si me regresa una sentencia user() vacia tendrá id = 0
            if (userToken == "")
                return BadRequest("Invalid email or password");
            
            return Ok(userToken);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add( UserCreateDTO UserCreateDto ) 
        {                        // User <= UserCreateDto       // src <= dest    
            var Entity = _mapper.Map<User>(UserCreateDto); 
            Entity.Password = _usersService.HashPassword( Entity.Password );

            await _usersService.Add(Entity);

            var userDto = _mapper.Map<UserDTO>( Entity ); //I converted my entity to show my UserDto on the swagger

            return CreatedAtAction( nameof( GetById ), new { id = Entity.IdUser }, userDto); //? <--- i don´t know nothing of this.
        }

        [Authorize(Policy = "Usuario")]
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompleteUserInformation(int id, CompleteUserInformationDTO completeUserInformationDto) //actualiza los datos por llenar.
        {
            if (id <= 0 || completeUserInformationDto == null)
            {
                return BadRequest("Invalid id or user data");
            }

            var user = await _usersService.GetById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Upload image if provided
            if (completeUserInformationDto.Image != null)
            {
                var imageUrl = await _imageUploadService.UploadImageAsync(completeUserInformationDto.Image);
                user.ProfilePhotoUrl = imageUrl;
            }

            // Map remaining user information
            _mapper.Map(completeUserInformationDto, user);

            await _usersService.Update(user);
            return NoContent();
        }

        [Authorize(Policy = "Usuario")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUserInformation(int id, UserUpdateDTO updateUserDto) //actualiza los datos por llenar.
        {
            if (id <= 0 || updateUserDto == null)
            {
                return BadRequest("Invalid id or user data");
            }

            var user = await _usersService.GetById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Check if a new image is provided
            if (updateUserDto.Image != null)
            {
                // Upload the new image to Cloudinary
                var newImageUrl = await _imageUploadService.UploadImageAsync(updateUserDto.Image);

                // Delete the previous image from Cloudinary if it exists
                if (!string.IsNullOrEmpty(user.ProfilePhotoUrl))
                {
                    await _imageUploadService.DeleteImageAsync(user.ProfilePhotoUrl);
                }

                // Update the user's profile photo URL with the new one
                user.ProfilePhotoUrl = newImageUrl;
            }

            // Map only the properties that are not null in updateUserDto to the user entity
            _mapper.Map(updateUserDto, user);

            await _usersService.Update(user);
            return NoContent();
        }

    }
}