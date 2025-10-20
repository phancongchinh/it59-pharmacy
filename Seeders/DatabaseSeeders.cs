using System;
using System.Collections.Generic;
using System.Linq;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Seeders {
    public static class DatabaseSeeder {
        private static readonly Random _random = new Random();

        // Vietnamese sample data for random generation
        private static readonly string[] VietnameseFirstNames =
        {
            "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng",
            "Bùi", "Đỗ", "Hồ", "Ngô", "Dương", "Lý", "Mai", "Đinh", "Tô", "Lưu"
        };

        private static readonly string[] VietnameseMiddleNames =
        {
            "Văn", "Thị", "Minh", "Hoàng", "Thanh", "Thu", "Hữu", "Đức", "Quang", "Anh",
            "Tuấn", "Hải", "Lan", "Hương", "Linh", "Nam", "Phương", "Tâm", "Xuân", "Bảo"
        };

        private static readonly string[] VietnameseLastNames =
        {
            "An", "Bình", "Cường", "Dũng", "Em", "Giang", "Hà", "Khánh", "Long", "Mai",
            "Nam", "Oanh", "Phúc", "Quý", "Sơn", "Thắng", "Uyên", "Vinh", "Xuân", "Yến"
        };

        private static readonly string[] VietnameseCompanyTypes =
        {
            "Dược phẩm", "Y tế", "Thiết bị y tế", "Phân phối dược", "Công ty dược",
            "Nhà thuốc", "Y khoa", "Chăm sóc sức khỏe", "Dược liệu", "Sinh dược"
        };

        private static readonly string[] VietnameseCities =
        {
            "Hồ Chí Minh", "Hà Nội", "Đà Nẵng", "Hải Phòng", "Cần Thơ", "Biên Hòa", "Huế", "Nha Trang",
            "Buôn Ma Thuột", "Quy Nhon", "Vũng Tàu", "Nam Định", "Thái Nguyên", "Bắc Ninh", "Vinh", "Long Xuyên"
        };

        private static readonly string[] VietnameseStreets =
        {
            "Lê Lợi", "Nguyễn Huệ", "Trần Hưng Đạo", "Hai Bà Trưng", "Điện Biên Phủ", "Lý Thường Kiệt",
            "Hoàng Văn Thụ", "Phan Chu Trinh", "Võ Thị Sáu", "Lê Duẩn", "Cách Mạng Tháng 8"
        };

        private static readonly string[] VietnameseDistricts =
        {
            "Quận 1", "Quận 3", "Quận 5", "Quận 7", "Quận Bình Thạnh", "Quận Tân Bình",
            "Quận Phú Nhuận", "Quận Gò Vấp", "Quận Thủ Đức", "Quận 10", "Quận 11"
        };

        public static void Seed(AppDbContext context) {
            try
            {
                // Check if users already exist
                if (context.Users.Any())
                    return; // Data already seeded

                // Use Southeast Asia timezone for seeding
                var seAsiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, seAsiaTimeZone);

                // Create the default admin user first (without audit fields to avoid circular reference)
                var adminUser = new User
                {
                    Username = "admin",
                    FullName = "Quản trị viên hệ thống",
                    Email = "admin@nhathuoc.vn",
                    PasswordHash = AuthenticationService.HashPassword("1"), 
                    Role = UserRole.Administrator,
                    PhoneNumber = "028-3825-1234",
                    IsActive = true,
                    CreatedDate = currentTime
                };

                context.Users.Add(adminUser);
                
                context.SaveChanges();

                // Get the admin user ID to use it for other entities
                var savedAdmin = context.Users.First(u => u.Username == "admin");

                // Update the admin user to reference itself as creator
                savedAdmin.CreatedById = savedAdmin.Id;
                context.SaveChanges();

                // Create 20 other users with proper CreatedById
                var otherUsers = new List<User>();
                var userRoles = new[] { UserRole.WarehouseManager, UserRole.Cashier };

                for (int i = 0; i < 20; i++)
                {
                    var firstName = VietnameseFirstNames[_random.Next(VietnameseFirstNames.Length)];
                    var middleName = VietnameseMiddleNames[_random.Next(VietnameseMiddleNames.Length)];
                    var lastName = VietnameseLastNames[_random.Next(VietnameseLastNames.Length)];
                    var role = userRoles[_random.Next(userRoles.Length)];
                    var username = GenerateVietnameseUsername(firstName, lastName, i);

                    otherUsers.Add(new User
                    {
                        Username = username,
                        FullName = $"{firstName} {middleName} {lastName}",
                        Email = $"{username}@nhathuoc.vn",
                        PasswordHash = AuthenticationService.HashPassword("password123"),
                        Role = role,
                        PhoneNumber = GenerateVietnamesePhoneNumber(),
                        IsActive = _random.Next(100) < 90, // 90% active
                        CreatedById = savedAdmin.Id,
                        CreatedDate = currentTime.AddDays(-_random.Next(180)) // Random date within last 6 months
                    });
                }

                context.Users.AddRange(otherUsers);

                // Create 36 medicine categories in Vietnamese
                var medicineCategories = new List<MedicineCategory>
                {
                    // Prescription Categories
                    new MedicineCategory
                    {
                        Name = "Kháng sinh", Description = "Thuốc điều trị nhiễm khuẩn do vi khuẩn", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Kháng virus", Description = "Thuốc điều trị nhiễm virus", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Kháng nấm", Description = "Thuốc điều trị nhiễm nấm", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Thuốc giảm đau", Description = "Thuốc giảm đau và chống viêm", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Chống viêm", Description = "Thuốc chống viêm không steroid", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Tim mạch", Description = "Thuốc điều trị bệnh tim mạch", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Hô hấp", Description = "Thuốc điều trị bệnh đường hô hấp", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Tiêu hóa", Description = "Thuốc điều trị bệnh đường tiêu hóa", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Thần kinh", Description = "Thuốc điều trị bệnh thần kinh", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Tâm thần", Description = "Thuốc điều trị bệnh tâm thần", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Nội tiết", Description = "Thuốc điều trị rối loạn nội tiết", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Tiểu đường", Description = "Thuốc điều trị bệnh tiểu đường", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Tăng huyết áp", Description = "Thuốc điều trị tăng huyết áp", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Cholesterol", Description = "Thuốc điều trị rối loạn lipid máu", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Kháng histamin", Description = "Thuốc điều trị dị ứng", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Ức chế miễn dịch", Description = "Thuốc ức chế hệ miễn dịch", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Ung thư học", Description = "Thuốc điều trị ung thư", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Da liễu", Description = "Thuốc điều trị bệnh da", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Mắt", Description = "Thuốc điều trị bệnh mắt", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Xương khớp", Description = "Thuốc điều trị bệnh xương khớp", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Gây tê", Description = "Thuốc gây tê và giảm đau", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Cấp cứu", Description = "Thuốc cấp cứu và chăm sóc tích cực", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },

                    // OTC Categories
                    new MedicineCategory
                    {
                        Name = "Vitamin", Description = "Vitamin thiết yếu", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Khoáng chất", Description = "Khoáng chất thiết yếu", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Thảo dược", Description = "Thực phẩm chức năng từ thảo dược", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Men vi sinh", Description = "Men vi sinh có lợi", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Cảm cúm", Description = "Thuốc điều trị cảm lạnh và cúm", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Tiêu hóa OTC", Description = "Thuốc hỗ trợ tiêu hóa không kê đơn", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Hỗ trợ ngủ", Description = "Sản phẩm hỗ trợ giấc ngủ", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Sơ cứu", Description = "Vật tư y tế sơ cứu cơ bản", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Chăm sóc cá nhân", Description = "Sản phẩm chăm sóc và vệ sinh cá nhân",
                        IsActive = true, CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Chăm sóc em bé", Description = "Sản phẩm chăm sóc trẻ sơ sinh và em bé",
                        IsActive = true, CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Sức khỏe phụ nữ", Description = "Sản phẩm chăm sóc sức khỏe phụ nữ", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Sức khỏe nam giới", Description = "Sản phẩm chăm sóc sức khỏe nam giới",
                        IsActive = true, CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Chăm sóc người cao tuổi", Description = "Sản phẩm chăm sóc người cao tuổi",
                        IsActive = true, CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    },
                    new MedicineCategory
                    {
                        Name = "Dinh dưỡng thể thao", Description = "Thực phẩm bổ sung cho thể thao", IsActive = true,
                        CreatedById = savedAdmin.Id, CreatedDate = currentTime
                    }
                };

                context.MedicineCategories.AddRange(medicineCategories);

                // Create 50 suppliers with Vietnamese attributes
                var suppliers = new List<Supplier>();
                for (int i = 0; i < 50; i++)
                {
                    var companyType = VietnameseCompanyTypes[_random.Next(VietnameseCompanyTypes.Length)];
                    var city = VietnameseCities[_random.Next(VietnameseCities.Length)];
                    var street = VietnameseStreets[_random.Next(VietnameseStreets.Length)];
                    var district = VietnameseDistricts[_random.Next(VietnameseDistricts.Length)];
                    var contactFirstName = VietnameseFirstNames[_random.Next(VietnameseFirstNames.Length)];
                    var contactMiddleName = VietnameseMiddleNames[_random.Next(VietnameseMiddleNames.Length)];
                    var contactLastName = VietnameseLastNames[_random.Next(VietnameseLastNames.Length)];

                    suppliers.Add(new Supplier
                    {
                        Name = $"{companyType} {city} {i + 1}",
                        Address = $"{_random.Next(1, 999)} {street}, {district}, {city}",
                        PhoneNumber = GenerateVietnamesePhoneNumber(),
                        Email = GenerateVietnameseEmail(city, companyType, i),
                        ContactPerson = $"{contactFirstName} {contactMiddleName} {contactLastName}",
                        IsActive = _random.Next(100) < 95, // 95% active
                        CreatedById = savedAdmin.Id,
                        CreatedDate = currentTime.AddDays(-_random.Next(365)) // Random date within last year
                    });
                }

                context.Suppliers.AddRange(suppliers);

                // Save changes
                context.SaveChanges();

                Console.WriteLine("Database seeded successfully with Vietnamese data!");
                Console.WriteLine($"- 1 Quản trị viên");
                Console.WriteLine($"- 20 Người dùng khác");
                Console.WriteLine($"- 36 Danh mục thuốc");
                Console.WriteLine($"- 50 Nhà cung cấp");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding database: {ex.Message}");
                throw;
            }
        }

        private static string GenerateVietnameseUsername(string firstName, string lastName, int index) {
            // Remove Vietnamese diacritics for username
            var cleanFirstName = RemoveVietnameseDiacritics(firstName).ToLower();
            var cleanLastName = RemoveVietnameseDiacritics(lastName).ToLower();
            return $"{cleanFirstName}.{cleanLastName}{index + 1}";
        }

        private static string GenerateVietnamesePhoneNumber() {
            // Generate Vietnamese phone numbers in format: 0xxx-xxx-xxx or +84-xxx-xxx-xxx
            var formats = new[] { "0", "+84" };
            var format = formats[_random.Next(formats.Length)];

            if (format == "0")
            {
                // Mobile: 09x, 08x, 07x, 05x, 03x
                var prefixes = new[]
                {
                    "090", "091", "094", "083", "084", "085", "070", "076", "077", "078", "079", "056", "058", "059",
                    "032", "033", "034", "035", "036", "037", "038", "039"
                };
                var prefix = prefixes[_random.Next(prefixes.Length)];
                return $"{prefix}-{_random.Next(100, 999)}-{_random.Next(100, 999)}";
            }
            else
            {
                // International format
                var prefixes = new[]
                {
                    "90", "91", "94", "83", "84", "85", "70", "76", "77", "78", "79", "56", "58", "59", "32", "33",
                    "34", "35", "36", "37", "38", "39"
                };
                var prefix = prefixes[_random.Next(prefixes.Length)];
                return $"+84-{prefix}-{_random.Next(100, 999)}-{_random.Next(100, 999)}";
            }
        }

        private static string GenerateVietnameseEmail(string city, string companyType, int index) {
            var cleanCity = RemoveVietnameseDiacritics(city).Replace(" ", "").ToLower();
            var cleanCompany = RemoveVietnameseDiacritics(companyType).Replace(" ", "").ToLower();
            var domains = new[] { "gmail.com", "yahoo.com", "outlook.com", "nhathuoc.vn", "duocpham.vn" };
            var domain = domains[_random.Next(domains.Length)];

            return $"{cleanCity}.{cleanCompany}{index + 1}@{domain}";
        }

        private static string RemoveVietnameseDiacritics(string text) {
            var vietnameseChars = new Dictionary<char, char>
            {
                { 'à', 'a' }, { 'á', 'a' }, { 'ạ', 'a' }, { 'ả', 'a' }, { 'ã', 'a' }, { 'â', 'a' }, { 'ầ', 'a' },
                { 'ấ', 'a' }, { 'ậ', 'a' }, { 'ẩ', 'a' }, { 'ẫ', 'a' }, { 'ă', 'a' }, { 'ằ', 'a' }, { 'ắ', 'a' },
                { 'ặ', 'a' }, { 'ẳ', 'a' }, { 'ẵ', 'a' },
                { 'è', 'e' }, { 'é', 'e' }, { 'ẹ', 'e' }, { 'ẻ', 'e' }, { 'ẽ', 'e' }, { 'ê', 'e' }, { 'ề', 'e' },
                { 'ế', 'e' }, { 'ệ', 'e' }, { 'ể', 'e' }, { 'ễ', 'e' },
                { 'ì', 'i' }, { 'í', 'i' }, { 'ị', 'i' }, { 'ỉ', 'i' }, { 'ĩ', 'i' },
                { 'ò', 'o' }, { 'ó', 'o' }, { 'ọ', 'o' }, { 'ỏ', 'o' }, { 'õ', 'o' }, { 'ô', 'o' }, { 'ồ', 'o' },
                { 'ố', 'o' }, { 'ộ', 'o' }, { 'ổ', 'o' }, { 'ỗ', 'o' }, { 'ơ', 'o' }, { 'ờ', 'o' }, { 'ớ', 'o' },
                { 'ợ', 'o' }, { 'ở', 'o' }, { 'ỡ', 'o' },
                { 'ù', 'u' }, { 'ú', 'u' }, { 'ụ', 'u' }, { 'ủ', 'u' }, { 'ũ', 'u' }, { 'ư', 'u' }, { 'ừ', 'u' },
                { 'ứ', 'u' }, { 'ự', 'u' }, { 'ử', 'u' }, { 'ữ', 'u' },
                { 'ỳ', 'y' }, { 'ý', 'y' }, { 'ỵ', 'y' }, { 'ỷ', 'y' }, { 'ỹ', 'y' },
                { 'đ', 'd' },
                { 'À', 'A' }, { 'Á', 'A' }, { 'Ạ', 'A' }, { 'Ả', 'A' }, { 'Ã', 'A' }, { 'Â', 'A' }, { 'Ầ', 'A' },
                { 'Ấ', 'A' }, { 'Ậ', 'A' }, { 'Ẩ', 'A' }, { 'Ẫ', 'A' }, { 'Ă', 'A' }, { 'Ằ', 'A' }, { 'Ắ', 'A' },
                { 'Ặ', 'A' }, { 'Ẳ', 'A' }, { 'Ẵ', 'A' },
                { 'È', 'E' }, { 'É', 'E' }, { 'Ẹ', 'E' }, { 'Ẻ', 'E' }, { 'Ẽ', 'E' }, { 'Ê', 'E' }, { 'Ề', 'E' },
                { 'Ế', 'E' }, { 'Ệ', 'E' }, { 'Ể', 'E' }, { 'Ễ', 'E' },
                { 'Ì', 'I' }, { 'Í', 'I' }, { 'Ị', 'I' }, { 'Ỉ', 'I' }, { 'Ĩ', 'I' },
                { 'Ò', 'O' }, { 'Ó', 'O' }, { 'Ọ', 'O' }, { 'Ỏ', 'O' }, { 'Õ', 'O' }, { 'Ô', 'O' }, { 'Ồ', 'O' },
                { 'Ố', 'O' }, { 'Ộ', 'O' }, { 'Ổ', 'O' }, { 'Ỗ', 'O' }, { 'Ơ', 'O' }, { 'Ờ', 'O' }, { 'Ớ', 'O' },
                { 'Ợ', 'O' }, { 'Ở', 'O' }, { 'Ỡ', 'O' },
                { 'Ù', 'U' }, { 'Ú', 'U' }, { 'Ụ', 'U' }, { 'Ủ', 'U' }, { 'Ũ', 'U' }, { 'Ư', 'U' }, { 'Ừ', 'U' },
                { 'Ứ', 'U' }, { 'Ự', 'U' }, { 'Ử', 'U' }, { 'Ữ', 'U' },
                { 'Ỳ', 'Y' }, { 'Ý', 'Y' }, { 'Ỵ', 'Y' }, { 'Ỷ', 'Y' }, { 'Ỹ', 'Y' },
                { 'Đ', 'D' }
            };

            var result = new System.Text.StringBuilder();
            foreach (char c in text)
            {
                if (vietnameseChars.TryGetValue(c, out char replacement))
                    result.Append(replacement);
                else
                    result.Append(c);
            }

            return result.ToString();
        }
    }
}
