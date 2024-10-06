﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdtTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CopyID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ReturnByDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookLoans_BookCopies_CopyID",
                        column: x => x.CopyID,
                        principalTable: "BookCopies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Authors", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Raymond E. Feist", "A loyal soldier and a wealthy merchant have served bravely in the flames of an enduring war that is ravaging their land. But swords, bows, wits and courage will no longer be enough to defeat the scourge that is descending upon their home. For a foul and terrible thing has escaped from a world already devoured to feed on one consumed by chaos—an insatiable nightmare creature of dark and murderous nature which seeks to own and corrupt the very source of life itself The final conflict is joined, pitting serpent against man and magician against demon. For those who battle in the cause of good, there will be victory . . . or there will be doom for all. There can be no other outcome.", "Rage of a Demon King" },
                    { 2, "Raymond E. Feist", "Winter's icy grasp is loosening on the world. The Emerald Queen's vanquished army has its broken back to the Bitter Sea. And treachery is their only recourse. A lackey has declared himself Lord of the defeated, massing the still fearsome remnants of a ruthless fighting force together for one final assault on a weakened, vulnerable realm. His dread scheme relies upon subterfuge and bitter betrayals. And when he strikes, his attack will be unanticipated and unprepared-for...and launched with a horrifying ferocity born of desperation, greed and vengeance. For the warriors who remained steadfast against terrible numbers, for the magicians who nearly exhausted their powers to salvage a future, for the courageous souls who barely survived a devastating onslaught upon their homeland, the time to rebuild and renew has not yet come. The war is not over in Midkemia. And Jimmy and Dash, two young noble brothers who stand at the center of a gathering storm, are impelled to action that could secure a tenuous peace...or turn triumph into catastrophe. Once more, the fates of Roo Avery and Erik von Darkmoor; of the scheming Duko and malevolent Fadawah; of Pug, Nakor, mysterious Miranda; and all the villains, royals, soldiers, thieves and sorcerers who populate this singular world are woven together into a rich tapestry of heroic deeds and devastating consequence. SHARDS OF A BROKEN CROWN is an extraordinary achievement by the bestselling storyteller whose name has become synonymous with unparalleled epic fantasy: Raymond E. Feist.", "Shards of a Broken Crown" },
                    { 3, "Raymond E. Feist", "The RiftWar is done. But a fearsome army of trolls and renegade humans, emboldened by the drug of destruction, has risen in strength from the ashes of defeat. There is one, however, who defies the call to battle... New York Times bestselling fantasist Raymond E. Feist returns to a beleaguered realm of wonders and magic-where war is an enduring legacy; where blood swells the rivers and nourishes the land. Attend to this hitherto untold chapter in the violent history of Midkemia -- a towering saga of great conflicts, brave acts and insidious intrigues. It is the story of a traitor who rejects the brutality of his warlike kind and casts his lot with the human targets of their fierce aggression. It tells of mysterious deaths and sinister machinations -- and signs of a time when the fate of many civilizations rested in the able, unfaltering hands of RiftWar veterans Squire Locklear and cunning their-turned-squire Jimmy the Hand. It chronicles the powerful awakening of Owyn -- apprentice magician of untried strengths -- and celebrates the selfless achievements of Pug, the great sorcerer of two worlds. Welcome now to astonishing new corners of a world you have not yet fully explored-and prepare to experience true excitement, blood chilling terror...and the triumph born from the doom aimed at the beating heart of a kingdom.", "Krondor: the Betrayal" },
                    { 4, "Raymond E. Feist", "From a premier fantasist and author of the Riftwar Legacy comes the first installment in an much-anticipated new series. . . . “Feist has a natural talent for keeping the reader turning the pages.”—Chicago Sun-Times From the New York Times bestselling author comes a thrilling new epic of adventure and deceit set in his signature world of Midkemia. In a distant land, high among the snow-capped mountains, a peaceful nation is mercilessly put to the sword . . . yet one will survive. Little more than a boy, Talon of the Silver Hawk must carry on until, someday, he can take vengeance. Leaving the icy fastness of his ancient home, Talon descends into the dangerous land of his adversary. Treading a perilous path, he must survive battlefields, court intrigues, treacherous enemies, backstabbing friends, and beautiful yet deadly women to discover the evil responsible for the annihilation of his people.", "Talon of the Silver Hawk" },
                    { 5, "Raymond E. Feist", "New York Times bestselling author Raymond E. Feist returns us now to a place of unparalleled wonders--a sprawling kingdom coveted by enemies on all sides; a bustling center of commerce and magic, vibrantly alive and eternally in conflict. This is Midkemia, where great heroes are bred, and its glorious center... Krondor Prince Arutha--newly returned from battle--is concerned about a rash of unexplained assassinations that plagues his capital city. And so he commissions his most trusted agent, Squire James--formerly the thief known as \"Jimmy the Hand\"--to discover the source of the deadly epidemic. The answers seem to lie far beneath the streets in the dank depths of Krondor, where a terrible war rages in secret between two rival criminal gangs: those who call themselves \"Mockers\" and others in the thrall of a mysterious being known as \"The Crawler.\" But the deeper the Squire delves, the closer he gets to the true nature of the horror that has left untold dead in its wake. And unless James can prevent one last, unthinkable slaying, the nightmare forces of corruption and deceit will destroy his liege and reduce his beloved Krondor to ruins.", "Krondor: the Assassins" },
                    { 6, "Raymond E. Feist", "“A massive, entertaining tale.” —Ft. Lauderdale Sun-Sentinel The Serpentwar rages on! In Rage of a Demon King—the spellbinding third installment in Raymond E. Feist’s masterful epic fantasy, The Serpentwar Saga—the imperiled realm of Midkemia confronts its most devastating horror, as a nightmare beyond imagining descends upon the war-torn land determined to devour and destroy. A terrible conflict reaches a breathtaking climax—a world-annihilating conflagration that pits serpent against man and magician against demon. Rage of a Demon King is Feist at his best, solidifying his standing along with Terry Goodkind, George R. R. Martin, and Terry Brooks, as the elite creators of epic sword and sorcery fantasy.", "Rage of a Demon King" },
                    { 7, "Raymond E. Feist", "Following Talon of the Silver Hawk and King of Foxes, here is the third exciting volume in the Conclave of Shadows trilogy from the acclaimed author “in the forefront of contemporary fantasy adventure” (Library Journal) Tal Hawkins has succeeded in wreaking revenge on Kaspar, the evil Duke of Olasko. Banished to a distant land, Kaspar begins a journey that will take him halfway around the world. Reduced to the role of farm-hand, then common laborer, the former ruler endures dangers and horrors beyond his imagination as he struggles to return home. But fate, or some dark agency, has more in store for the man who was once tyrant of Olasko. As he travels, he is chosen to play a part in a much larger drama, a struggle between good and evil ages in the making. Dark powers are again in motion, and Kaspar discovers the herald of a threat not seen across the land since the legendary Riftwar and Serpentwar: A dark empire in a distant realm seeks entrance to Midkemia and Kaspar has unwittingly discovered the key. Now it is up to this unlikely hero to save Midkemia from the threat of unconditional defeat—and utter destruction.", "Exile's Return" },
                    { 8, "Raymond E. Feist", "The second enthralling installment in the highly praised Conclave of Shadows series—an epic saga of adventure, danger, magic, and intrigue from the New York Times bestselling master Rescued, recruited, and trained by the mysterious Conclave of Shadows, Tal Hawkins, hero of Talon of the Silver Hawk has become one of their most effective operatives. But to destroy the nemesis who annihilated his people, the evil Duke of Olasko, Tad must sell his soul. Masquerading as a noble from the far western territory of the Kingdom of the Isles, he must insinuate himself into the duke’s confidence and carry out his most heinous and dangerous commands—even though it means betraying his own moral code. Driven to the brink, Tal eventually defies the duke—and is imprisoned and left to die in the Fortress of Despair. But the determined young man will not be beaten. Alone, armed only with his courage and wits, Tal makes a daring escape. Returning to Olasko, he will finally brings revenge on his hated enemy.", "King of Foxes" },
                    { 9, "Raymond E. Feist", "Book three of The Riftwar Legacy The final instalment of Feist’s spellbinding Krondor adventure. Now in a brilliant new livery. ‘Feist writes fantasy of epic scope, fast-moving action and vivid imagination’ – Washington Post", "Krondor: Tear of the Gods" },
                    { 10, "Raymond E. Feist", "Ten years beyond the Darkwar, the demon hordes are relentless in their quest to subjugate a realm of magic and wonder . . . The defeat of the Demon King Maarg hasn't stemmed the death tide, and an even graver danger now looms. The fearsome demon Dahun and the mad necromancer Belasco have joined forces—a union of black magics that no power on Midkemia may be strong enough to withstand. The conflict has already claimed the lives of nearly everyone dear to the Black Sorcerer Pug. In uneasy alliance with the Conclave of Shadows, Midkemia's clandestine protectors, the distraught champion must stand firm against the demonic plague that has overrun worlds. And at the gates of darkness—where shadows hide deeper shadows—Midkemia's most terrible battle will be joined . . . as a malevolence beyond anything that came before is unleashed upon the world.", "At the Gates of Darkness" },
                    { 11, "Raymond E. Feist", "After nearly thirty years and more than two dozen novels, Raymond E. Feist's Riftwar Cycle has become one of the most iconic, beloved, and enduring sagas in modern fantasy. The Riftwars—including the original Riftwar, the Serpentwar, the Darkwar, and the Demonwar—were epic battles between Good and Evil whose ramifications have echoed through generations. The latest entry in the epic, A Kingdom Besieged, ushers in the most fearsome threat the Kingdom has yet faced—the Chaoswar—a magic apocalypse with cataclysmic results. A Kingdom Besieged Years ago, the Empire of Great Kesh failed in its attempt to conquer Krondor after the Serpentwar, thanks to the bravery, cunning, and magic of the sorcerer Pug and the Conclave of Shadows. Since then, peace has benefitted both nations, and the Kingdom has been free from the threat of another Keshian invasion. Yet now, the dark clouds of war gather again. . . . From the Far Coast in the west to the frontier with the Eastern Kingdoms, rumors, uncertainty, and political instability are rampant. Spies have gone missing—some were murdered while others have turned traitor. Factions are rising, powerful legions from the Keshian Confederacy have been mobilized, and an attack on the kingdoms of the Isles and Roldem is all but certain. As the men of the Western Realm begin to mount a defense, Martin conDoin, the middle son of Lord Henry, Duke of Crydee, finds himself leading the charge against the invaders—like his legendary ancestor, Prince Arutha, who stood firm to the death against the Tsurani invasion. But Arutha had an entire army at his command. Martin has just a ragtag force comprised of a few old men and young boys. As Kesh's invading hordes once again descend upon the Kingdom, no one is safe—not experienced masters of intrigue Lord James Dasher Jamison and the beguiling and deadly Lady Franciezka; not the brave warrior Knight-Adamant Sandreena and a new generation of loyal yet untested defenders; not even the great Pug himself, the most powerful magician the world of Midkemia has ever known. A threat far more terrifying has arisen, an evil whose burgeoning power portends Midkemia's demise. And soon even the Kingdom's enchanted defender will find himself questioning everything he's ever held abiding, true, and treasured . . . including the loyalty and desires of his beloved son, Magnus.", "A Kingdom Besieged" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "DateOfBirth", "Forename", "Surname", "Title" },
                values: new object[] { 1, new DateTime(1998, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dave", "Daveson", "Dr" });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "ID", "BookID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookID",
                table: "BookCopies",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_CopyID",
                table: "BookLoans",
                column: "CopyID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_MemberID",
                table: "BookLoans",
                column: "MemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
