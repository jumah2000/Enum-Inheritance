namespace ConsoleAppCleanProject.Domain.Services;

public static class VendorServiceRepository
{
    private static Admin _admin = new Admin(); 
    private static List<Vendor> _vendors = new List<Vendor>();

    // Admin validation
    public static bool ValidateAdmin(string adminId, string password)
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

    // Create
    public static void AddVendor(string name, string age, string address, Gender gender)
    {
       var vendor = new Vendor(name, age, address, gender);
        _vendors.Add(vendor);
    }

    // Read by ID
    public static Vendor GetVendorById(string vendorId)
    {
        return _vendors.Find(x => x.VendorId == vendorId);
    }

    // Read all
    public static List<Vendor> GetAllVendors()
    {
        return _vendors;
    }

    // Delete
    public static bool DeleteVendor(string vendorId)
    {
        var vendor = _vendors.Find(x => x.VendorId == vendorId);
        if (vendor != null)
        {
            _vendors.Remove(vendor);
            return true;
        }
        return false;
    }
}
