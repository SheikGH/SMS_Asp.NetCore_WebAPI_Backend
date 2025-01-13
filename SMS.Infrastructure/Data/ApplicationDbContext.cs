using Microsoft.EntityFrameworkCore;
using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data
{
    /// <summary>
    /// Install packages Microsoft.EntityFrameworkCore version 7.0.20 which is compartible with net 7.0
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<StudentNationality> StudentNationalities { get; set; }
        public DbSet<FamilyMemberNationality> FamilyMemberNationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            //modelBuilder.Entity<Student>().HasMany(s => s.StudentNationalities).WithOne(sn => sn.Student);
            //modelBuilder.Entity<Student>().HasMany(s => s.FamilyMembers).WithOne(fm => fm.Student);

            //modelBuilder.Entity<FamilyMember>().HasMany(fm => fm.FamilyMemberNationalities).WithOne(fmn => fmn.FamilyMember);
            //modelBuilder.Entity<FamilyMember>().HasOne(fm => fm.Relationship).WithMany(r => r.FamilyMembers);

            //modelBuilder.Entity<StudentNationality>().HasOne(sn => sn.Nationality).WithMany(n => n.StudentNationalities);
            //modelBuilder.Entity<FamilyMemberNationality>().HasOne(fmn => fmn.Nationality).WithMany(n => n.FamilyMemberNationalities);

            //modelBuilder.Entity<StudentNationality>().HasKey(sn => new { sn.StudentId, sn.NationalityId });

            //modelBuilder.Entity<StudentNationality>()
            //    .HasOne(sn => sn.Student)
            //    .WithMany(s => s.StudentNationalities);
            //    //.HasForeignKey(sn => sn.StudentId);

            //modelBuilder.Entity<StudentNationality>()
            //    .HasOne(sn => sn.Nationality)
            //    .WithMany(n => n.StudentNationalities);
            //    //.HasForeignKey(sn => sn.NationalityId);

            //modelBuilder.Entity<FamilyMemberNationality>().HasKey(sn => new { sn.FamilyMemberId, sn.NationalityId });

            //modelBuilder.Entity<FamilyMemberNationality>()
            //    .HasOne(sn => sn.FamilyMember)
            //    .WithMany(s => s.FamilyMemberNationalities);
            ////.HasForeignKey(sn => sn.FamilyMemberId);

            //modelBuilder.Entity<FamilyMemberNationality>()
            //    .HasOne(sn => sn.Nationality)
            //    .WithMany(n => n.FamilyMemberNationalities);
            //    //.HasForeignKey(sn => sn.NationalityId);

            modelBuilder.Entity<Student>().HasKey(s => s.ID); // Primary Key
            modelBuilder.Entity<Student>().Property(s => s.ID).ValueGeneratedOnAdd(); // Identity column
            // Seed data
            modelBuilder.Entity<Nationality>().HasData(
                    new Nationality { ID = 1, Name = "Afghanistan", Code = "AF" },
                    new Nationality { ID = 2, Name = "land Islands", Code = "AX" },
                    new Nationality { ID = 3, Name = "Albania", Code = "AL" },
                    new Nationality { ID = 4, Name = "Algeria", Code = "DZ" },
                    new Nationality { ID = 5, Name = "American Samoa", Code = "AS" },
                    new Nationality { ID = 6, Name = "AndorrA", Code = "AD" },
                    new Nationality { ID = 7, Name = "Angola", Code = "AO" },
                    new Nationality { ID = 8, Name = "Anguilla", Code = "AI" },
                    new Nationality { ID = 9, Name = "Antarctica", Code = "AQ" },
                    new Nationality { ID = 10, Name = "Antigua and Barbuda", Code = "AG" },
                    new Nationality { ID = 11, Name = "Argentina", Code = "AR" },
                    new Nationality { ID = 12, Name = "Armenia", Code = "AM" },
                    new Nationality { ID = 13, Name = "Aruba", Code = "AW" },
                    new Nationality { ID = 14, Name = "Australia", Code = "AU" },
                    new Nationality { ID = 15, Name = "Austria", Code = "AT" },
                    new Nationality { ID = 16, Name = "Azerbaijan", Code = "AZ" },
                    new Nationality { ID = 17, Name = "Bahamas", Code = "BS" },
                    new Nationality { ID = 18, Name = "Bahrain", Code = "BH" },
                    new Nationality { ID = 19, Name = "Bangladesh", Code = "BD" },
                    new Nationality { ID = 20, Name = "Barbados", Code = "BB" },
                    new Nationality { ID = 21, Name = "Belarus", Code = "BY" },
                    new Nationality { ID = 22, Name = "Belgium", Code = "BE" },
                    new Nationality { ID = 23, Name = "Belize", Code = "BZ" },
                    new Nationality { ID = 24, Name = "Benin", Code = "BJ" },
                    new Nationality { ID = 25, Name = "Bermuda", Code = "BM" },
                    new Nationality { ID = 26, Name = "Bhutan", Code = "BT" },
                    new Nationality { ID = 27, Name = "Bolivia", Code = "BO" },
                    new Nationality { ID = 28, Name = "Bosnia and Herzegovina", Code = "BA" },
                    new Nationality { ID = 29, Name = "Botswana", Code = "BW" },
                    new Nationality { ID = 30, Name = "Bouvet Island", Code = "BV" },
                    new Nationality { ID = 31, Name = "Brazil", Code = "BR" },
                    new Nationality { ID = 32, Name = "British Indian Ocean Territory", Code = "IO" },
                    new Nationality { ID = 33, Name = "Brunei Darussalam", Code = "BN" },
                    new Nationality { ID = 34, Name = "Bulgaria", Code = "BG" },
                    new Nationality { ID = 35, Name = "Burkina Faso", Code = "BF" },
                    new Nationality { ID = 36, Name = "Burundi", Code = "BI" },
                    new Nationality { ID = 37, Name = "Cambodia", Code = "KH" },
                    new Nationality { ID = 38, Name = "Cameroon", Code = "CM" },
                    new Nationality { ID = 39, Name = "Canada", Code = "CA" },
                    new Nationality { ID = 40, Name = "Cape Verde", Code = "CV" },
                    new Nationality { ID = 41, Name = "Cayman Islands", Code = "KY" },
                    new Nationality { ID = 42, Name = "Central African Republic", Code = "CF" },
                    new Nationality { ID = 43, Name = "Chad", Code = "TD" },
                    new Nationality { ID = 44, Name = "Chile", Code = "CL" },
                    new Nationality { ID = 45, Name = "China", Code = "CN" },
                    new Nationality { ID = 46, Name = "Christmas Island", Code = "CX" },
                    new Nationality { ID = 47, Name = "Cocos (Keeling) Islands", Code = "CC" },
                    new Nationality { ID = 48, Name = "Colombia", Code = "CO" },
                    new Nationality { ID = 49, Name = "Comoros", Code = "KM" },
                    new Nationality { ID = 50, Name = "Congo", Code = "CG" },
                    new Nationality { ID = 51, Name = "Congo, The Democratic Republic of the", Code = "CD" },
                    new Nationality { ID = 52, Name = "Cook Islands", Code = "CK" },
                    new Nationality { ID = 53, Name = "Costa Rica", Code = "CR" },
                    new Nationality { ID = 54, Name = "Cote D\"Ivoire", Code = "CI" },
                    new Nationality { ID = 55, Name = "Croatia", Code = "HR" },
                    new Nationality { ID = 56, Name = "Cuba", Code = "CU" },
                    new Nationality { ID = 57, Name = "Cyprus", Code = "CY" },
                    new Nationality { ID = 58, Name = "Czech Republic", Code = "CZ" },
                    new Nationality { ID = 59, Name = "Denmark", Code = "DK" },
                    new Nationality { ID = 60, Name = "Djibouti", Code = "DJ" },
                    new Nationality { ID = 61, Name = "Dominica", Code = "DM" },
                    new Nationality { ID = 62, Name = "Dominican Republic", Code = "DO" },
                    new Nationality { ID = 63, Name = "Ecuador", Code = "EC" },
                    new Nationality { ID = 64, Name = "Egypt", Code = "EG" },
                    new Nationality { ID = 65, Name = "El Salvador", Code = "SV" },
                    new Nationality { ID = 66, Name = "Equatorial Guinea", Code = "GQ" },
                    new Nationality { ID = 67, Name = "Eritrea", Code = "ER" },
                    new Nationality { ID = 68, Name = "Estonia", Code = "EE" },
                    new Nationality { ID = 69, Name = "Ethiopia", Code = "ET" },
                    new Nationality { ID = 70, Name = "Falkland Islands (Malvinas)", Code = "FK" },
                    new Nationality { ID = 71, Name = "Faroe Islands", Code = "FO" },
                    new Nationality { ID = 72, Name = "Fiji", Code = "FJ" },
                    new Nationality { ID = 73, Name = "Finland", Code = "FI" },
                    new Nationality { ID = 74, Name = "France", Code = "FR" },
                    new Nationality { ID = 75, Name = "French Guiana", Code = "GF" },
                    new Nationality { ID = 76, Name = "French Polynesia", Code = "PF" },
                    new Nationality { ID = 77, Name = "French Southern Territories", Code = "TF" },
                    new Nationality { ID = 78, Name = "Gabon", Code = "GA" },
                    new Nationality { ID = 79, Name = "Gambia", Code = "GM" },
                    new Nationality { ID = 80, Name = "Georgia", Code = "GE" },
                    new Nationality { ID = 81, Name = "Germany", Code = "DE" },
                    new Nationality { ID = 82, Name = "Ghana", Code = "GH" },
                    new Nationality { ID = 83, Name = "Gibraltar", Code = "GI" },
                    new Nationality { ID = 84, Name = "Greece", Code = "GR" },
                    new Nationality { ID = 85, Name = "Greenland", Code = "GL" },
                    new Nationality { ID = 86, Name = "Grenada", Code = "GD" },
                    new Nationality { ID = 87, Name = "Guadeloupe", Code = "GP" },
                    new Nationality { ID = 88, Name = "Guam", Code = "GU" },
                    new Nationality { ID = 89, Name = "Guatemala", Code = "GT" },
                    new Nationality { ID = 90, Name = "Guernsey", Code = "GG" },
                    new Nationality { ID = 91, Name = "Guinea", Code = "GN" },
                    new Nationality { ID = 92, Name = "Guinea-Bissau", Code = "GW" },
                    new Nationality { ID = 93, Name = "Guyana", Code = "GY" },
                    new Nationality { ID = 94, Name = "Haiti", Code = "HT" },
                    new Nationality { ID = 95, Name = "Heard Island and Mcdonald Islands", Code = "HM" },
                    new Nationality { ID = 96, Name = "Holy See (Vatican City State)", Code = "VA" },
                    new Nationality { ID = 97, Name = "Honduras", Code = "HN" },
                    new Nationality { ID = 98, Name = "Hong Kong", Code = "HK" },
                    new Nationality { ID = 99, Name = "Hungary", Code = "HU" },
                    new Nationality { ID = 100, Name = "Iceland", Code = "IS" },
                    new Nationality { ID = 101, Name = "India", Code = "IN" },
                    new Nationality { ID = 102, Name = "Indonesia", Code = "ID" },
                    new Nationality { ID = 103, Name = "Iran, Islamic Republic Of", Code = "IR" },
                    new Nationality { ID = 104, Name = "Iraq", Code = "IQ" },
                    new Nationality { ID = 105, Name = "Ireland", Code = "IE" },
                    new Nationality { ID = 106, Name = "Isle of Man", Code = "IM" },
                    new Nationality { ID = 107, Name = "Israel", Code = "IL" },
                    new Nationality { ID = 108, Name = "Italy", Code = "IT" },
                    new Nationality { ID = 109, Name = "Jamaica", Code = "JM" },
                    new Nationality { ID = 110, Name = "Japan", Code = "JP" },
                    new Nationality { ID = 111, Name = "Jersey", Code = "JE" },
                    new Nationality { ID = 112, Name = "Jordan", Code = "JO" },
                    new Nationality { ID = 113, Name = "Kazakhstan", Code = "KZ" },
                    new Nationality { ID = 114, Name = "Kenya", Code = "KE" },
                    new Nationality { ID = 115, Name = "Kiribati", Code = "KI" },
                    new Nationality { ID = 116, Name = "Korea, Democratic People\"S Republic of", Code = "KP" },
                    new Nationality { ID = 117, Name = "Korea, Republic of", Code = "KR" },
                    new Nationality { ID = 118, Name = "Kuwait", Code = "KW" },
                    new Nationality { ID = 119, Name = "Kyrgyzstan", Code = "KG" },
                    new Nationality { ID = 120, Name = "Lao People\"S Democratic Republic", Code = "LA" },
                    new Nationality { ID = 121, Name = "Latvia", Code = "LV" },
                    new Nationality { ID = 122, Name = "Lebanon", Code = "LB" },
                    new Nationality { ID = 123, Name = "Lesotho", Code = "LS" },
                    new Nationality { ID = 124, Name = "Liberia", Code = "LR" },
                    new Nationality { ID = 125, Name = "Libyan Arab Jamahiriya", Code = "LY" },
                    new Nationality { ID = 126, Name = "Liechtenstein", Code = "LI" },
                    new Nationality { ID = 127, Name = "Lithuania", Code = "LT" },
                    new Nationality { ID = 128, Name = "Luxembourg", Code = "LU" },
                    new Nationality { ID = 129, Name = "Macao", Code = "MO" },
                    new Nationality { ID = 130, Name = "Macedonia, The Former Yugoslav Republic of", Code = "MK" },
                    new Nationality { ID = 131, Name = "Madagascar", Code = "MG" },
                    new Nationality { ID = 132, Name = "Malawi", Code = "MW" },
                    new Nationality { ID = 133, Name = "Malaysia", Code = "MY" },
                    new Nationality { ID = 134, Name = "Maldives", Code = "MV" },
                    new Nationality { ID = 135, Name = "Mali", Code = "ML" },
                    new Nationality { ID = 136, Name = "Malta", Code = "MT" },
                    new Nationality { ID = 137, Name = "Marshall Islands", Code = "MH" },
                    new Nationality { ID = 138, Name = "Martinique", Code = "MQ" },
                    new Nationality { ID = 139, Name = "Mauritania", Code = "MR" },
                    new Nationality { ID = 140, Name = "Mauritius", Code = "MU" },
                    new Nationality { ID = 141, Name = "Mayotte", Code = "YT" },
                    new Nationality { ID = 142, Name = "Mexico", Code = "MX" },
                    new Nationality { ID = 143, Name = "Micronesia, Federated States of", Code = "FM" },
                    new Nationality { ID = 144, Name = "Moldova, Republic of", Code = "MD" },
                    new Nationality { ID = 145, Name = "Monaco", Code = "MC" },
                    new Nationality { ID = 146, Name = "Mongolia", Code = "MN" },
                    new Nationality { ID = 147, Name = "Montenegro", Code = "ME" },
                    new Nationality { ID = 148, Name = "Montserrat", Code = "MS" },
                    new Nationality { ID = 149, Name = "Morocco", Code = "MA" },
                    new Nationality { ID = 150, Name = "Mozambique", Code = "MZ" },
                    new Nationality { ID = 151, Name = "Myanmar", Code = "MM" },
                    new Nationality { ID = 152, Name = "Namibia", Code = "NA" },
                    new Nationality { ID = 153, Name = "Nauru", Code = "NR" },
                    new Nationality { ID = 154, Name = "Nepal", Code = "NP" },
                    new Nationality { ID = 155, Name = "Netherlands", Code = "NL" },
                    new Nationality { ID = 156, Name = "Netherlands Antilles", Code = "AN" },
                    new Nationality { ID = 157, Name = "New Caledonia", Code = "NC" },
                    new Nationality { ID = 158, Name = "New Zealand", Code = "NZ" },
                    new Nationality { ID = 159, Name = "Nicaragua", Code = "NI" },
                    new Nationality { ID = 160, Name = "Niger", Code = "NE" },
                    new Nationality { ID = 161, Name = "Nigeria", Code = "NG" },
                    new Nationality { ID = 162, Name = "Niue", Code = "NU" },
                    new Nationality { ID = 163, Name = "Norfolk Island", Code = "NF" },
                    new Nationality { ID = 164, Name = "Northern Mariana Islands", Code = "MP" },
                    new Nationality { ID = 165, Name = "Norway", Code = "NO" },
                    new Nationality { ID = 166, Name = "Oman", Code = "OM" },
                    new Nationality { ID = 167, Name = "Pakistan", Code = "PK" },
                    new Nationality { ID = 168, Name = "Palau", Code = "PW" },
                    new Nationality { ID = 169, Name = "Palestinian Territory, Occupied", Code = "PS" },
                    new Nationality { ID = 170, Name = "Panama", Code = "PA" },
                    new Nationality { ID = 171, Name = "Papua New Guinea", Code = "PG" },
                    new Nationality { ID = 172, Name = "Paraguay", Code = "PY" },
                    new Nationality { ID = 173, Name = "Peru", Code = "PE" },
                    new Nationality { ID = 174, Name = "Philippines", Code = "PH" },
                    new Nationality { ID = 175, Name = "Pitcairn", Code = "PN" },
                    new Nationality { ID = 176, Name = "Poland", Code = "PL" },
                    new Nationality { ID = 177, Name = "Portugal", Code = "PT" },
                    new Nationality { ID = 178, Name = "Puerto Rico", Code = "PR" },
                    new Nationality { ID = 179, Name = "Qatar", Code = "QA" },
                    new Nationality { ID = 180, Name = "Reunion", Code = "RE" },
                    new Nationality { ID = 181, Name = "Romania", Code = "RO" },
                    new Nationality { ID = 182, Name = "Russian Federation", Code = "RU" },
                    new Nationality { ID = 183, Name = "RWANDA", Code = "RW" },
                    new Nationality { ID = 184, Name = "Saint Helena", Code = "SH" },
                    new Nationality { ID = 185, Name = "Saint Kitts and Nevis", Code = "KN" },
                    new Nationality { ID = 186, Name = "Saint Lucia", Code = "LC" },
                    new Nationality { ID = 187, Name = "Saint Pierre and Miquelon", Code = "PM" },
                    new Nationality { ID = 188, Name = "Saint Vincent and the Grenadines", Code = "VC" },
                    new Nationality { ID = 189, Name = "Samoa", Code = "WS" },
                    new Nationality { ID = 190, Name = "San Marino", Code = "SM" },
                    new Nationality { ID = 191, Name = "Sao Tome and Principe", Code = "ST" },
                    new Nationality { ID = 192, Name = "Saudi Arabia", Code = "SA" },
                    new Nationality { ID = 193, Name = "Senegal", Code = "SN" },
                    new Nationality { ID = 194, Name = "Serbia", Code = "RS" },
                    new Nationality { ID = 195, Name = "Seychelles", Code = "SC" },
                    new Nationality { ID = 196, Name = "Sierra Leone", Code = "SL" },
                    new Nationality { ID = 197, Name = "Singapore", Code = "SG" },
                    new Nationality { ID = 198, Name = "Slovakia", Code = "SK" },
                    new Nationality { ID = 199, Name = "Slovenia", Code = "SI" },
                    new Nationality { ID = 200, Name = "Solomon Islands", Code = "SB" },
                    new Nationality { ID = 201, Name = "Somalia", Code = "SO" },
                    new Nationality { ID = 202, Name = "South Africa", Code = "ZA" },
                    new Nationality { ID = 203, Name = "South Georgia and the South Sandwich Islands", Code = "GS" },
                    new Nationality { ID = 204, Name = "Spain", Code = "ES" },
                    new Nationality { ID = 205, Name = "Sri Lanka", Code = "LK" },
                    new Nationality { ID = 206, Name = "Sudan", Code = "SD" },
                    new Nationality { ID = 207, Name = "Suriname", Code = "SR" },
                    new Nationality { ID = 208, Name = "Svalbard and Jan Mayen", Code = "SJ" },
                    new Nationality { ID = 209, Name = "Swaziland", Code = "SZ" },
                    new Nationality { ID = 210, Name = "Sweden", Code = "SE" },
                    new Nationality { ID = 211, Name = "Switzerland", Code = "CH" },
                    new Nationality { ID = 212, Name = "Syrian Arab Republic", Code = "SY" },
                    new Nationality { ID = 213, Name = "Taiwan, Province of China", Code = "TW" },
                    new Nationality { ID = 214, Name = "Tajikistan", Code = "TJ" },
                    new Nationality { ID = 215, Name = "Tanzania, United Republic of", Code = "TZ" },
                    new Nationality { ID = 216, Name = "Thailand", Code = "TH" },
                    new Nationality { ID = 217, Name = "Timor-Leste", Code = "TL" },
                    new Nationality { ID = 218, Name = "Togo", Code = "TG" },
                    new Nationality { ID = 219, Name = "Tokelau", Code = "TK" },
                    new Nationality { ID = 220, Name = "Tonga", Code = "TO" },
                    new Nationality { ID = 221, Name = "Trinidad and Tobago", Code = "TT" },
                    new Nationality { ID = 222, Name = "Tunisia", Code = "TN" },
                    new Nationality { ID = 223, Name = "Turkey", Code = "TR" },
                    new Nationality { ID = 224, Name = "Turkmenistan", Code = "TM" },
                    new Nationality { ID = 225, Name = "Turks and Caicos Islands", Code = "TC" },
                    new Nationality { ID = 226, Name = "Tuvalu", Code = "TV" },
                    new Nationality { ID = 227, Name = "Uganda", Code = "UG" },
                    new Nationality { ID = 228, Name = "Ukraine", Code = "UA" },
                    new Nationality { ID = 229, Name = "United Arab Emirates", Code = "AE" },
                    new Nationality { ID = 230, Name = "United Kingdom", Code = "GB" },
                    new Nationality { ID = 231, Name = "United States", Code = "US" },
                    new Nationality { ID = 232, Name = "United States Minor Outlying Islands", Code = "UM" },
                    new Nationality { ID = 233, Name = "Uruguay", Code = "UY" },
                    new Nationality { ID = 234, Name = "Uzbekistan", Code = "UZ" },
                    new Nationality { ID = 235, Name = "Vanuatu", Code = "VU" },
                    new Nationality { ID = 236, Name = "Venezuela", Code = "VE" },
                    new Nationality { ID = 237, Name = "Viet Nam", Code = "VN" },
                    new Nationality { ID = 238, Name = "Virgin Islands, British", Code = "VG" },
                    new Nationality { ID = 239, Name = "Virgin Islands, U.S.", Code = "VI" },
                    new Nationality { ID = 240, Name = "Wallis and Futuna", Code = "WF" },
                    new Nationality { ID = 241, Name = "Western Sahara", Code = "EH" },
                    new Nationality { ID = 242, Name = "Yemen", Code = "YE" },
                    new Nationality { ID = 243, Name = "Zambia", Code = "ZM" },
                    new Nationality { ID = 244, Name = "Zimbabwe", Code = "ZW" }
            );

            modelBuilder.Entity<Relationship>().HasData(
                new Relationship { ID = 1, Name = "Parent" },
                new Relationship { ID = 2, Name = "Sibling" },
                new Relationship { ID = 3, Name = "Spouse" }
            );

            modelBuilder.Entity<StudentNationality>().HasData(
                new StudentNationality { ID = 1, NationalityId = 1, StudentId = 1 },
                new StudentNationality { ID = 2, NationalityId = 5, StudentId = 2 },
                new StudentNationality { ID = 3, NationalityId = 97, StudentId = 3 },
                new StudentNationality { ID = 4, NationalityId = 40, StudentId = 4 },
                new StudentNationality { ID = 5, NationalityId = 9, StudentId = 5 },
                new StudentNationality { ID = 6, NationalityId = 77, StudentId = 6 }
            );

            modelBuilder.Entity<FamilyMemberNationality>().HasData(
                new FamilyMemberNationality { ID = 1, NationalityId = 1, FamilyMemberId = 1 },
                new FamilyMemberNationality { ID = 2, NationalityId = 5, FamilyMemberId = 2 },
                new FamilyMemberNationality { ID = 3, NationalityId = 97, FamilyMemberId = 3 },
                new FamilyMemberNationality { ID = 4, NationalityId = 40, FamilyMemberId = 4 },
                new FamilyMemberNationality { ID = 5, NationalityId = 9, FamilyMemberId = 5 },
                new FamilyMemberNationality { ID = 6, NationalityId = 77, FamilyMemberId = 6 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(2000, 3, 15), Status = "Active" },
                new Student { ID = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1983, 1, 11), Status = "Active" },
                new Student { ID = 3, FirstName = "Leanne", LastName = "Graham", DateOfBirth = new DateTime(2010, 7, 1), Status = "Active" },
                new Student { ID = 4, FirstName = "Dennis", LastName = "Schulist", DateOfBirth = new DateTime(1798, 12, 31), Status = "Active" },
                new Student { ID = 5, FirstName = "Glenna", LastName = "Reichert", DateOfBirth = new DateTime(2000, 10, 19), Status = "Active" },
                new Student { ID = 6, FirstName = "Ervin", LastName = "Howell", DateOfBirth = new DateTime(2004, 4, 24), Status = "Active" }
            );

            modelBuilder.Entity<FamilyMember>().HasData(
                new FamilyMember { ID = 1, StudentId = 1, FirstName = "Harry", LastName = "Joe", DateOfBirth = new DateTime(1975, 5, 15), RelationshipId = 1 },
                new FamilyMember { ID = 2, StudentId = 2, FirstName = "Jack", LastName = "Connor", DateOfBirth = new DateTime(1983, 10, 21), RelationshipId = 2 },
                new FamilyMember { ID = 3, StudentId = 6, FirstName = "Smith", LastName = "Roberts", DateOfBirth = new DateTime(2013, 7, 1), RelationshipId = 3 },
                new FamilyMember { ID = 4, StudentId = 4, FirstName = "George", LastName = "Rhys", DateOfBirth = new DateTime(1898, 12, 31), RelationshipId = 3 },
                new FamilyMember { ID = 5, StudentId = 5, FirstName = "Alexander", LastName = "Joseph", DateOfBirth = new DateTime(2020, 10, 19), RelationshipId = 1 },
                new FamilyMember { ID = 6, StudentId = 3, FirstName = "William", LastName = "Damian", DateOfBirth = new DateTime(2017, 4, 28), RelationshipId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
