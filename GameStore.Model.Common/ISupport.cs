
namespace GameStore.Model.Common
{
    public interface ISupport
    {
        int Id { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }

        // One to one
        ICompany Company { get; set; }

    }
}
