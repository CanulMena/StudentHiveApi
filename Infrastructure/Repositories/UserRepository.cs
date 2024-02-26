using System.IO.Compression;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;


namespace StudentHive.Infrastructure.Repositories;
//*It is le logic of database services ----- this is my datasource
public class UserRepository
{
    private readonly StudentHiveDbContext _context; //*Here i am interactuanding with my database
    public UserRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    { //only returns users<Users>
        var users = await _context.Users
        .Include(u => u.RentalHouses) // Incluye las casas en alquiler asociadas a cada usuario
        .Include(u => u.RentalHouses).ThenInclude(rh => rh.IdHouseServiceNavigation) // Incluye los servicios de cada casa en alquiler
        .Include(u => u.RentalHouses).ThenInclude(rh => rh.IdLocationNavigation) // Incluye las ubicaciones de cada casa en alquiler
        .Include(u => u.RentalHouses).ThenInclude(rh => rh.IdRentalHouseDetailNavigation) // Incluye los detalles de alquiler de cada casa en alquiler
        .Include(u => u.RentalHouses).ThenInclude(rh => rh.Images) // Incluye las imágenes de cada casa en alquiler
        .ToListAsync();

    return users;
    }

    public async Task<User> GetById(int id)
    {   /*
        *me regresa todas las casas relacionadas con el usuario,
        pero como esa entidad contiene otras entidades las tengo que agregar con el 
        ThenInclude para poder llamarlas de igual menera  
        *al final solo filstro que me regrese el primer usuario que tenga el mismo id que agregue como parametro */
        var user = await _context.Users
            .Include(u => u.RentalHouses) /* --> */
            .Include(u => u.RentalHouses).ThenInclude(listRH => listRH.IdHouseServiceNavigation) /* --> */
            .Include(u => u.RentalHouses).ThenInclude(listRH => listRH.IdLocationNavigation) /* --> */
            .Include(u => u.RentalHouses).ThenInclude(listRH => listRH.IdRentalHouseDetailNavigation) /* --> */
            .Include(u => u.RentalHouses).ThenInclude(listRH => listRH.Images) /* --> */
            .FirstOrDefaultAsync(u => u.IdUser == id);

        return user ?? new User();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _context.Users
        .FirstOrDefaultAsync(user => user.Email == email);
        return user ?? new User();
    }

    public async Task Add(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
}
    }


