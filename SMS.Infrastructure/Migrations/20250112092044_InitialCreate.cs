using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyMemberNationalities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberNationalities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentNationalities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNationalities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "FamilyMemberNationalities",
                columns: new[] { "ID", "FamilyMemberId", "NationalityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 5 },
                    { 3, 3, 97 },
                    { 4, 4, 40 },
                    { 5, 5, 9 },
                    { 6, 6, 77 }
                });

            migrationBuilder.InsertData(
                table: "FamilyMembers",
                columns: new[] { "ID", "DateOfBirth", "FirstName", "LastName", "RelationshipId", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(1975, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry", "Joe", 1, 1 },
                    { 2, new DateTime(1983, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack", "Connor", 2, 2 },
                    { 3, new DateTime(2013, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "Roberts", 3, 6 },
                    { 4, new DateTime(1898, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", "Rhys", 3, 4 },
                    { 5, new DateTime(2020, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander", "Joseph", 1, 5 },
                    { 6, new DateTime(2017, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Damian", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "ID", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "AF", "Afghanistan" },
                    { 2, "AX", "land Islands" },
                    { 3, "AL", "Albania" },
                    { 4, "DZ", "Algeria" },
                    { 5, "AS", "American Samoa" },
                    { 6, "AD", "AndorrA" },
                    { 7, "AO", "Angola" },
                    { 8, "AI", "Anguilla" },
                    { 9, "AQ", "Antarctica" },
                    { 10, "AG", "Antigua and Barbuda" },
                    { 11, "AR", "Argentina" },
                    { 12, "AM", "Armenia" },
                    { 13, "AW", "Aruba" },
                    { 14, "AU", "Australia" },
                    { 15, "AT", "Austria" },
                    { 16, "AZ", "Azerbaijan" },
                    { 17, "BS", "Bahamas" },
                    { 18, "BH", "Bahrain" },
                    { 19, "BD", "Bangladesh" },
                    { 20, "BB", "Barbados" },
                    { 21, "BY", "Belarus" },
                    { 22, "BE", "Belgium" },
                    { 23, "BZ", "Belize" },
                    { 24, "BJ", "Benin" },
                    { 25, "BM", "Bermuda" },
                    { 26, "BT", "Bhutan" },
                    { 27, "BO", "Bolivia" },
                    { 28, "BA", "Bosnia and Herzegovina" },
                    { 29, "BW", "Botswana" },
                    { 30, "BV", "Bouvet Island" },
                    { 31, "BR", "Brazil" },
                    { 32, "IO", "British Indian Ocean Territory" },
                    { 33, "BN", "Brunei Darussalam" },
                    { 34, "BG", "Bulgaria" },
                    { 35, "BF", "Burkina Faso" },
                    { 36, "BI", "Burundi" },
                    { 37, "KH", "Cambodia" },
                    { 38, "CM", "Cameroon" },
                    { 39, "CA", "Canada" },
                    { 40, "CV", "Cape Verde" },
                    { 41, "KY", "Cayman Islands" },
                    { 42, "CF", "Central African Republic" },
                    { 43, "TD", "Chad" },
                    { 44, "CL", "Chile" },
                    { 45, "CN", "China" },
                    { 46, "CX", "Christmas Island" },
                    { 47, "CC", "Cocos (Keeling) Islands" },
                    { 48, "CO", "Colombia" },
                    { 49, "KM", "Comoros" },
                    { 50, "CG", "Congo" },
                    { 51, "CD", "Congo, The Democratic Republic of the" },
                    { 52, "CK", "Cook Islands" },
                    { 53, "CR", "Costa Rica" },
                    { 54, "CI", "Cote D\"Ivoire" },
                    { 55, "HR", "Croatia" },
                    { 56, "CU", "Cuba" },
                    { 57, "CY", "Cyprus" },
                    { 58, "CZ", "Czech Republic" },
                    { 59, "DK", "Denmark" },
                    { 60, "DJ", "Djibouti" },
                    { 61, "DM", "Dominica" },
                    { 62, "DO", "Dominican Republic" },
                    { 63, "EC", "Ecuador" },
                    { 64, "EG", "Egypt" },
                    { 65, "SV", "El Salvador" },
                    { 66, "GQ", "Equatorial Guinea" },
                    { 67, "ER", "Eritrea" },
                    { 68, "EE", "Estonia" },
                    { 69, "ET", "Ethiopia" },
                    { 70, "FK", "Falkland Islands (Malvinas)" },
                    { 71, "FO", "Faroe Islands" },
                    { 72, "FJ", "Fiji" },
                    { 73, "FI", "Finland" },
                    { 74, "FR", "France" },
                    { 75, "GF", "French Guiana" },
                    { 76, "PF", "French Polynesia" },
                    { 77, "TF", "French Southern Territories" },
                    { 78, "GA", "Gabon" },
                    { 79, "GM", "Gambia" },
                    { 80, "GE", "Georgia" },
                    { 81, "DE", "Germany" },
                    { 82, "GH", "Ghana" },
                    { 83, "GI", "Gibraltar" },
                    { 84, "GR", "Greece" },
                    { 85, "GL", "Greenland" },
                    { 86, "GD", "Grenada" },
                    { 87, "GP", "Guadeloupe" },
                    { 88, "GU", "Guam" },
                    { 89, "GT", "Guatemala" },
                    { 90, "GG", "Guernsey" },
                    { 91, "GN", "Guinea" },
                    { 92, "GW", "Guinea-Bissau" },
                    { 93, "GY", "Guyana" },
                    { 94, "HT", "Haiti" },
                    { 95, "HM", "Heard Island and Mcdonald Islands" },
                    { 96, "VA", "Holy See (Vatican City State)" },
                    { 97, "HN", "Honduras" },
                    { 98, "HK", "Hong Kong" },
                    { 99, "HU", "Hungary" },
                    { 100, "IS", "Iceland" },
                    { 101, "IN", "India" },
                    { 102, "ID", "Indonesia" },
                    { 103, "IR", "Iran, Islamic Republic Of" },
                    { 104, "IQ", "Iraq" },
                    { 105, "IE", "Ireland" },
                    { 106, "IM", "Isle of Man" },
                    { 107, "IL", "Israel" },
                    { 108, "IT", "Italy" },
                    { 109, "JM", "Jamaica" },
                    { 110, "JP", "Japan" },
                    { 111, "JE", "Jersey" },
                    { 112, "JO", "Jordan" },
                    { 113, "KZ", "Kazakhstan" },
                    { 114, "KE", "Kenya" },
                    { 115, "KI", "Kiribati" },
                    { 116, "KP", "Korea, Democratic People\"S Republic of" },
                    { 117, "KR", "Korea, Republic of" },
                    { 118, "KW", "Kuwait" },
                    { 119, "KG", "Kyrgyzstan" },
                    { 120, "LA", "Lao People\"S Democratic Republic" },
                    { 121, "LV", "Latvia" },
                    { 122, "LB", "Lebanon" },
                    { 123, "LS", "Lesotho" },
                    { 124, "LR", "Liberia" },
                    { 125, "LY", "Libyan Arab Jamahiriya" },
                    { 126, "LI", "Liechtenstein" },
                    { 127, "LT", "Lithuania" },
                    { 128, "LU", "Luxembourg" },
                    { 129, "MO", "Macao" },
                    { 130, "MK", "Macedonia, The Former Yugoslav Republic of" },
                    { 131, "MG", "Madagascar" },
                    { 132, "MW", "Malawi" },
                    { 133, "MY", "Malaysia" },
                    { 134, "MV", "Maldives" },
                    { 135, "ML", "Mali" },
                    { 136, "MT", "Malta" },
                    { 137, "MH", "Marshall Islands" },
                    { 138, "MQ", "Martinique" },
                    { 139, "MR", "Mauritania" },
                    { 140, "MU", "Mauritius" },
                    { 141, "YT", "Mayotte" },
                    { 142, "MX", "Mexico" },
                    { 143, "FM", "Micronesia, Federated States of" },
                    { 144, "MD", "Moldova, Republic of" },
                    { 145, "MC", "Monaco" },
                    { 146, "MN", "Mongolia" },
                    { 147, "ME", "Montenegro" },
                    { 148, "MS", "Montserrat" },
                    { 149, "MA", "Morocco" },
                    { 150, "MZ", "Mozambique" },
                    { 151, "MM", "Myanmar" },
                    { 152, "NA", "Namibia" },
                    { 153, "NR", "Nauru" },
                    { 154, "NP", "Nepal" },
                    { 155, "NL", "Netherlands" },
                    { 156, "AN", "Netherlands Antilles" },
                    { 157, "NC", "New Caledonia" },
                    { 158, "NZ", "New Zealand" },
                    { 159, "NI", "Nicaragua" },
                    { 160, "NE", "Niger" },
                    { 161, "NG", "Nigeria" },
                    { 162, "NU", "Niue" },
                    { 163, "NF", "Norfolk Island" },
                    { 164, "MP", "Northern Mariana Islands" },
                    { 165, "NO", "Norway" },
                    { 166, "OM", "Oman" },
                    { 167, "PK", "Pakistan" },
                    { 168, "PW", "Palau" },
                    { 169, "PS", "Palestinian Territory, Occupied" },
                    { 170, "PA", "Panama" },
                    { 171, "PG", "Papua New Guinea" },
                    { 172, "PY", "Paraguay" },
                    { 173, "PE", "Peru" },
                    { 174, "PH", "Philippines" },
                    { 175, "PN", "Pitcairn" },
                    { 176, "PL", "Poland" },
                    { 177, "PT", "Portugal" },
                    { 178, "PR", "Puerto Rico" },
                    { 179, "QA", "Qatar" },
                    { 180, "RE", "Reunion" },
                    { 181, "RO", "Romania" },
                    { 182, "RU", "Russian Federation" },
                    { 183, "RW", "RWANDA" },
                    { 184, "SH", "Saint Helena" },
                    { 185, "KN", "Saint Kitts and Nevis" },
                    { 186, "LC", "Saint Lucia" },
                    { 187, "PM", "Saint Pierre and Miquelon" },
                    { 188, "VC", "Saint Vincent and the Grenadines" },
                    { 189, "WS", "Samoa" },
                    { 190, "SM", "San Marino" },
                    { 191, "ST", "Sao Tome and Principe" },
                    { 192, "SA", "Saudi Arabia" },
                    { 193, "SN", "Senegal" },
                    { 194, "RS", "Serbia" },
                    { 195, "SC", "Seychelles" },
                    { 196, "SL", "Sierra Leone" },
                    { 197, "SG", "Singapore" },
                    { 198, "SK", "Slovakia" },
                    { 199, "SI", "Slovenia" },
                    { 200, "SB", "Solomon Islands" },
                    { 201, "SO", "Somalia" },
                    { 202, "ZA", "South Africa" },
                    { 203, "GS", "South Georgia and the South Sandwich Islands" },
                    { 204, "ES", "Spain" },
                    { 205, "LK", "Sri Lanka" },
                    { 206, "SD", "Sudan" },
                    { 207, "SR", "Suriname" },
                    { 208, "SJ", "Svalbard and Jan Mayen" },
                    { 209, "SZ", "Swaziland" },
                    { 210, "SE", "Sweden" },
                    { 211, "CH", "Switzerland" },
                    { 212, "SY", "Syrian Arab Republic" },
                    { 213, "TW", "Taiwan, Province of China" },
                    { 214, "TJ", "Tajikistan" },
                    { 215, "TZ", "Tanzania, United Republic of" },
                    { 216, "TH", "Thailand" },
                    { 217, "TL", "Timor-Leste" },
                    { 218, "TG", "Togo" },
                    { 219, "TK", "Tokelau" },
                    { 220, "TO", "Tonga" },
                    { 221, "TT", "Trinidad and Tobago" },
                    { 222, "TN", "Tunisia" },
                    { 223, "TR", "Turkey" },
                    { 224, "TM", "Turkmenistan" },
                    { 225, "TC", "Turks and Caicos Islands" },
                    { 226, "TV", "Tuvalu" },
                    { 227, "UG", "Uganda" },
                    { 228, "UA", "Ukraine" },
                    { 229, "AE", "United Arab Emirates" },
                    { 230, "GB", "United Kingdom" },
                    { 231, "US", "United States" },
                    { 232, "UM", "United States Minor Outlying Islands" },
                    { 233, "UY", "Uruguay" },
                    { 234, "UZ", "Uzbekistan" },
                    { 235, "VU", "Vanuatu" },
                    { 236, "VE", "Venezuela" },
                    { 237, "VN", "Viet Nam" },
                    { 238, "VG", "Virgin Islands, British" },
                    { 239, "VI", "Virgin Islands, U.S." },
                    { 240, "WF", "Wallis and Futuna" },
                    { 241, "EH", "Western Sahara" },
                    { 242, "YE", "Yemen" },
                    { 243, "ZM", "Zambia" },
                    { 244, "ZW", "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Parent" },
                    { 2, "Sibling" },
                    { 3, "Spouse" }
                });

            migrationBuilder.InsertData(
                table: "StudentNationalities",
                columns: new[] { "ID", "NationalityId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 5, 2 },
                    { 3, 97, 3 },
                    { 4, 40, 4 },
                    { 5, 9, 5 },
                    { 6, 77, 6 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateOfBirth", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", "Active" },
                    { 2, new DateTime(1983, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", "Active" },
                    { 3, new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leanne", "Graham", "Active" },
                    { 4, new DateTime(1798, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dennis", "Schulist", "Active" },
                    { 5, new DateTime(2000, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glenna", "Reichert", "Active" },
                    { 6, new DateTime(2004, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ervin", "Howell", "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMemberNationalities");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "StudentNationalities");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
