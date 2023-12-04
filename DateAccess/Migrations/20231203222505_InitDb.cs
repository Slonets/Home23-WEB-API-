using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ganres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GanreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGanres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GanreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGanres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGanres_Ganres_GanreId",
                        column: x => x.GanreId,
                        principalTable: "Ganres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGanres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ganres",
                columns: new[] { "Id", "GanreName" },
                values: new object[,]
                {
                    { 1, "Бойовик" },
                    { 2, "Пригоди" },
                    { 3, "Історичний" },
                    { 4, "Драма" },
                    { 5, "Жахи" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 1, "У розпал Другої світової війни полковник США Леслі Гровс призначає блискучого фізика-теоретика Роберта Оппенгеймера науковим керівником Манхеттенського проєкту. Вся індустріальна міць та інноваційні технології країни йдуть на те, щоб випередити нацистську Німеччину у створенні зброї масового знищення на основі розщеплення ядра атома. Оппенгеймер проводить успішні випробування першої у світі ядерної бомби, що дозволяє наблизити перемогу у війні. Проте чоловіка мучать докори совісті, оскільки його винахід здатний призвести до знищення всього людства...", "https://uaserials.pro/posters/8215.jpg", "Оппенгеймер" },
                    { 2, "Події розгортаються у майбутньому, під час війни між людьми та штучним інтелектом. Колишній спецпризначенець Джошуа разом із загоном оперативників отримує завдання знайти та вбити архітектора просунутого штучного інтелекту — Творця, який розробив зброю, здатну покласти край не лише війні, а й усьому людству...", "https://uaserials.pro/posters/8224.jpg", "Творець" },
                    { 3, "Висококласний найманий убивця, схильний до мізантропічного філософування, чекає на жертву в Парижі. Коли все йде не за планом, він сам ризикує перетворитися на ціль і вирушає розбиратися зі своїми замовниками...", "https://uaserials.pro/posters/8216.jpg", "Вбивця" },
                    { 4, "Дія відбувається в 1947 році напередодні Хелловіну у Венеції, куди переїхав знаменитий детектив Еркюль Пуаро, що вийшов на пенсію. На прохання свого старого знайомого він неохоче відвідує спіритичний сеанс самопроголошеного медіума Джойс Рейнольдс, яку потрібно викрити як шахрайку. Незабаром після сеансу жінка-медіум трагічно гине, що змушує гостей, які зібралися в особняку, повірити в існування злих духів. Проте Пуаро переконаний, що сталося сплановане вбивство, яке йому належить розкрити.", "https://uaserials.pro/posters/8174.jpg", "Привиди у Венеції" },
                    { 5, "Американський секретний агент Ітан Гант, що очолює оперативну групу «Місія нездійсненна», цього разу стикається з майже невразливим ворогом: штучним інтелектом під назвою «Сутність», що вийшов з-під контролю. Єдиний спосіб перемогти розумну технологію, яка загрожує всьому людству — знайти дві половинки таємничого ключа і розгадати їх секрет. Головний герой та його команда знову повинні кинути виклик смерті та подолати межу власних можливостей, щоб урятувати весь світ від загрози знищення...", "https://uaserials.pro/posters/8127.jpg", "Місія нездійсненна: Розплата. Частина перша" },
                    { 6, "У Тіхуані урядовий агент відвідує старого друга Ніка Фальконе, який уже вийшов на пенсію, і просить його повернутися у стрій. Нік має виконати усунути три цілі, які вважаються небезпечними для національної безпеки США. Тим часом агент Управління боротьби з наркотиками Ентоні Ван Овен дізнається, що за вбивством Февзі Полата, відомого через зв'язки із великими злочинними угрупованнями, стоїть Нік. Вийшовши на слід досвідченого агента, Ентоні поєднується з Ніком, щоб зупинити могутнього кримінального ватажка від використання інноваційного пристрою, здатного повністю відключити електроенергію в мегаполісі.", "https://uaserials.pro/posters/8202.jpg", "Чорна мітка" },
                    { 7, "Лора Еш, беручи участь у викраденні коштовностей, обманює спільників і тікає до Парижа. Там вона стикається зі схожою на неї дівчиною, яка вчиняє самогубство. Лора вирішує скористатися ситуацією і видати загиблу за себе, а себе — за неї. Їй це вдається, але через сім років вона повертається до Парижа під ім'ям Лілі Воттс, вже як дружина нового посла США у Франції. Однак її колишні спільники продовжують пошуки вкрадених коштовностей...", "https://uaserials.pro/posters/8237.jpg", "Фатальна жінка" },
                    { 8, "Тесляр Серджіо та колишня співачка Сабріна закохані одне в одне, але не можуть кинути своїх партнерів через фінансову залежність. Проте ситуація різко змінюється, коли колеги переконують чоловіка, що він виграв три мільйони євро в лотерею. Серджіо одразу ж кидає старе життя та тягне за собою не тільки Сабріну, а й усіх родичів. Коли пара дізнається, що жодного виграшу немає, вони вирішують продовжити брехати своїм сім'ям і вирушають разом з ними в незвичайну подорож Італією. Однак таємне завжди стає явним...", "https://uaserials.pro/posters/8239.jpg", "Фантазери" },
                    { 9, "Цього року Стелла закінчує школу. У той час, коли подруги сидять за підручниками, батько йде до іншої, а мати на порозі депресії, Стелла відкриває для себе клубне життя 80-х і шалені нічні тусовки.", "https://uaserials.pro/posters/8201.jpg", "Стелла в Парижі" },
                    { 10, "Подружня пара Стіне та Тейт разом зі своїм маленьким сином Немо вирішує втекти з Копенгагена, щоб сховатися у віддаленій хатині у безкраїх лісах Швеції, бажаючи налагодити стосунки та знайти спокій. Жінка прагне подолати творчу кризу та закінчити свій перший роман, а чоловік має намір задокументувати їхню «пригоду» у серії подкастів. Перебуваючи в повній ізоляції від зовнішнього світу, подружжя стикається з низкою дивних подій і зустрічає таємничих незнайомців, які неймовірно схожі на них самих...", "https://uaserials.pro/posters/8221.jpg", "Ілюзія втечі" }
                });

            migrationBuilder.InsertData(
                table: "MovieGanres",
                columns: new[] { "Id", "GanreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 5, 5 },
                    { 6, 1, 6 },
                    { 7, 2, 7 },
                    { 9, 4, 9 },
                    { 10, 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGanres_GanreId",
                table: "MovieGanres",
                column: "GanreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGanres_MovieId",
                table: "MovieGanres",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGanres");

            migrationBuilder.DropTable(
                name: "Ganres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
