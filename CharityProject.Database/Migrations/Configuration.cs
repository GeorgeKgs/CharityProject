namespace CharityProject.Database.Migrations
{
    using CharityProject.Entities.DomainClasses;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CharityProject.Database.CharityDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CharityProject.Database.CharityDBContext context)
        {

            Plan p1 = new Plan() { Category = "Health" };
            Plan p2 = new Plan() { Category = "Education" };
            Plan p3 = new Plan() { Category = "Culture" };
           
            Partner partner1 = new Partner() { Name = "Acumen", Country = "USA", 
                                               Address = "40 Worth Street, NY", Latitude= 40.712776M, Longitude= -74.005974M, 
                                               Description = "Acumen was incorporated on April 1, 2001, with seed capital " +
                                               "from the Rockefeller Foundation, Cisco Systems Foundation and three individual" +
                                               " philanthropists. Our desire was to transform the world of philanthropy by looking at all " +
                                               "human beings as members of a single, global community where everyone had the opportunity to build" +
                                               " a life of dignity. The organization would invest “Patient Capital,” capital that bridges the " +
                                               "gap between the efficiency and scale of market-based approaches and the social " +
                                               "impact of pure philanthropy, in entrepreneurs bringing sustainable solutions" +
                                               " to big problems of poverty.",
                                               ImageUrl="/PartnersImages/acumen.jpg"
            };


            Partner partner2 = new Partner() { Name = "DRC", Country = "Denmark", 
                                               Address = "Borgergade 10, Copenhagen", Latitude = 55.676098M, Longitude = 12.568337M,
                                               Description= "The Danish Refugee Council assists refugees and internally displaced persons across the globe we provide emergency aid, " +
                                               "fight for their rights, and strengthen their opportunity for a brighter future. " +
                                               "We work in conflict - affected areas, along the displacement routes, " +
                                               "and in the countries where refugees settle.In cooperation with local communities, " +
                                               "we strive for responsible and sustainable solutions.We work toward successful integration and " +
                                               "- whenever possible – for the fulfillment of the wish to return home. " +
                                               "The Danish Refugee Council was founded in Denmark in 1956, " +
                                               "and has since grown to become an international humanitarian organization with more than 7,000 staff " +
                                               "and 8,000 volunteers.Our vision is a dignified life for all displaced.",
                                                ImageUrl = "/PartnersImages/drc.jpg"
            };

            Partner partner3 = new Partner() { Name = "IFRC", Country = "Switzerland", 
                                               Address = "Chemin 17, Geneva", Latitude = 46.204391M, Longitude = 6.143158M,
                                               Description = "The International Federation of Red Cross and Red Crescent Societies (IFRC) " +
                                               "is the world's largest humanitarian network that reaches 150 million people in 190 National Societies " +
                                               "through the work of over 13,7 million volunteers. Together, we act before, during and after disasters " +
                                               "and health emergencies to meet the needs and improve the lives of vulnerable people.We do so without" +
                                               " discrimination as to nationality, race, religious beliefs, class or political opinions.Guided by " +
                                               "Strategy 2020 – our collective plan of action to tackle the major humanitarian and development " +
                                               "challenges of this decade – we are committed, in this fast-changing world, " +
                                               "to ‘saving lives and changing minds’. Our strength is in our volunteer network, " +
                                               "our community-based expertise and our ability to give a global voice to vulnerable people. " +
                                               "By improving humanitarian standards, working as partners in development, responding to disasters, " +
                                               "supporting healthier and safer communities, we help reduce vulnerabilities, strengthen resilience " +
                                               "and foster a culture of peace around the world.", 
                                                ImageUrl = "/PartnersImages/ifrc.jpeg"
            };


            Partner partner4 = new Partner()
            {
                Name = "Mercy Corps",
                Country = "Scotland",
                Address = "Edinburgh EH6 6LX",
                Latitude = 55.953251M,
                Longitude = -3.188267M,
                Description = "Mercy Corps is a global team of humanitarians who partner with communities, corporations and governments to" +
                " transform lives around the world.Our mission: to alleviate suffering, poverty and oppression by helping people build secure, " +
                "productive and just communities. Our 5,500+ team members work with people in the world’s most vulnerable " +
                "communities across 40+ countries. 87 percent of our team is from the countries where they work.Thanks to our donors, " +
                "we have provided $4 billion in lifesaving assistance to more than 220 million people over the last 40 years. " +
                "We believe we must go beyond emergency aid to create more resilient communities, and we believe communities " +
                "are the best agents of their own change.Through close collaboration with community members and a wide variety " +
                "of organizations, we put bold solutions into action and help people triumph over adversity. For the refugee who " +
                "dreams of rebuilding her home, for the mother who wants a healthy future for her children — for millions of people" +
                " filled with the power of possibility — we connect people to the resources they need to build better, stronger lives.",
                ImageUrl = "/PartnersImages/mercycorps.jpg"
            };



            Partner partner5 = new Partner()
            {
                Name = "Samaritan's Purse",
                Country = "USA",
                Address = "Boone, North Carolina",
                Latitude = 36.204010M,
                Longitude = -81.669430M,
                Description = "The story of the Good Samaritan (Luke 10:30-37) gives a clear picture of God’s desire for us to help those " +
                "in desperate need wherever we find them. After describing how the Samaritan rescued a hurting man whom others had passed by, " +
                "Jesus told His hearers, “Go and do likewise.” For over 40 years, Samaritan’s Purse has done our utmost to follow Christ’s " +
                "command by going to the aid of the world’s poor, sick, and suffering. We are an effective means of reaching hurting people" +
                " in countries around the world with food, medicine, and other assistance in the Name of Jesus Christ. This, in turn, " +
                "earns us a hearing for the Gospel, the Good News of eternal life through Jesus Christ. As our teams work in crisis areas of " +
                "the world, people often ask, “Why did you come?” The answer is always the same: “We have come to help you in the Name of the " +
                "Lord Jesus Christ.” Our ministry is all about Jesus—first, last, and always. As the Apostle Paul said, “For we do not preach " +
                "ourselves, but Jesus Christ as Lord, and ourselves as yor servants for Jesus’ sake” (2 Corinthians 4:5, NIV). Mission Statement" +
                " Samaritan’s Purse is a nondenominational evangelical Christian organization providing spiritual and physical aid to hurting" +
                " people around the world. Since 1970, Samaritan’s Purse has helped meet needs of people who are victims of war, poverty," +
                " natural disasters, disease, and famine with the purpose of sharing God’s love through His Son, Jesus Christ. The organization" +
                " serves the Church worldwide to promote the Gospel of the Lord Jesus Christ.",
                ImageUrl = "/PartnersImages/samaritan.jpg"
            };


            Partner partner6 = new Partner()
            {
                Name = "Save The Children",
                Country = "UK",
                Address = "30 Orange Street, London",
                Latitude = 51.507351M,
                Longitude = -0.127758M,
                Description = "Around the world, too many children start life at a disadvantage simply because of who they are" +
                " and where they come from.Millions of children are dying from preventable causes, face poverty, violence, disease and hunger. " +
                "They are caught up in war zones and disasters they did nothing to create. And they are denied an education and other basic " +
                "rights owed to them. All children deserve better. We champion the rights and interests of children worldwide, " +
                "putting the most vulnerable children first. With 25,000 dedicated staff across 120 countries, we respond to major emergencies, " +
                "deliver innovative development programmes, and ensure children's voices are heard through our campaigning to build" +
                " a better future for and with children.",
                ImageUrl = "/PartnersImages/save.jpeg"
            };


            Partner partner7 = new Partner()
            {
                Name = "World Vision",
                Country = "USA",
                Address = "Federal Way, WA 98001",
                Latitude = 47.289520M,
                Longitude = -122.290290M,
                Description = "World Vision is an international partnership of Christians whose mission is to follow our Lord " +
                "and Savior Jesus Christ in working with the poor and oppressed to promote human transformation, seek justice, " +
                "and bear witness to the good news of the Kingdom of God.",
                ImageUrl = "/PartnersImages/wordvision.jpg"
            };


            Partner partner8 = new Partner()
            {
                Name = "Amurtel",
                Country = "Greece",
                Address = "Victoria Sqr 12",
                Latitude = 37.983810M,
                Longitude = 23.727539M,
                Description = "Women’s empowerment is Amurtel Greece’s essence. Didi hopes “to bring more of the refugee and" +
                " migrant women on staff” in the next two years, so that the center would be made for them and managed by them completely.",
                ImageUrl = "/PartnersImages/amurtel.jpg"
            };


            Partner partner9 = new Partner()
            {
                Name = "IRC",
                Country = "Australia",
                Address = "122 East 42nd Street",
                Latitude = -37.840935M,
                Longitude = 144.946457M,
                Description = "The International Rescue Committee responds to the world's worst humanitarian crises," +
                " helping to restore health, safety, education, economic wellbeing and power to people devastated " +
                "by conflict and disaster.",
                ImageUrl = "/PartnersImages/irc.jpg"
            };

            Partner partner10 = new Partner()
            {
                Name = "Medical Bridges",
                Country = "Nigeria",
                Address = "122 East 42nd Street",
                Latitude = 6.465422M,
                Longitude = 3.406448M,
                Description = "The International Rescue Committee responds to the world's worst humanitarian crises," +
               " helping to restore health, safety, education, economic wellbeing and power to people devastated " +
               "by conflict and disaster.",
                ImageUrl = "/PartnersImages/bridges.jpg"
            };


            /*-----------------------------------------------------------------------*/

            Donation d1 = new Donation() 
            { 
                Title = "Voice of a Child U.S.", 
                Price = 2500.00M, 
                Partner = partner1, 
                Plan = p1,
                Description ="Help Infants Across the U.S."
            };


            Donation d2 = new Donation() 
            { 
                Title = "Help Juniata Community", 
                Price = 3500.00M,
                Partner = partner1, 
                Plan = p1,
                Description="Fund Juniata Community Schools."
            };

            Donation d3 = new Donation() 
            { 
                Title = "Adopt a Hero", 
                Price = 2000.00M, 
                Partner = partner3, 
                Plan = p1,
                Description="Help Stray Dogs."
            };

            Donation d4 = new Donation()
            {
                Title = "Good Samaritans",
                Price = 4000.00M,
                Partner = partner5,
                Plan = p3,
                Description = "For the public benefit, the relief and assistance of people in need."
            };

            Donation d5 = new Donation()
            {
                Title = "Coalition for Veterans",
                Price = 3200.00M,
                Partner = partner2,
                Plan = p2,
                Description = "Help victims of war or natural disasters."
            };

            Donation d6 = new Donation()
            {
                Title = "Cancer Exam Network",
                Price = 3200.00M,
                Partner = partner6,
                Plan = p1,
                Description = "Help victims of war or natural disasters."
            };

            Donation d7 = new Donation()
            {
                Title = "Helping Hands",
                Price = 1200.00M,
                Partner = partner4,
                Plan = p2,
                Description = " To advance education in accordance with x principles."
            };
           

            Donation d8 = new Donation()
            {
                Title = "Power to Our Vets",
                Price = 1200.00M,
                Partner = partner7,
                Plan = p1,
                Description = "prevention or relief of poverty for the public benefit."
            };


            Donation d9 = new Donation()
            {
                Title = "H2O for Life",
                Price = 3200.00M,
                Partner = partner9,
                Plan = p1,
                Description = "Provides clean drinking water and sanitation to African schools through programs with U.S. schools."
            };

            Donation d10 = new Donation()
            {
                Title = "BEADS for Education",
                Price = 6900.00M,
                Partner = partner10,
                Plan = p2,
                Description = "Improves the status of Kenyan girls through education."
            };

            Donation d11 = new Donation()
            {
                Title = "Books For Africa",
                Price = 2900.00M,
                Partner = partner10,
                Plan = p2,
                Description = "This includes textbooks, library books, law libraries, and agricultural books in English and French."
            };

            Donation d12 = new Donation()
            {
                Title = "Trees for the Future",
                Price = 1000.00M,
                Partner = partner9,
                Plan = p3,
                Description = "Provides technical training, planning, and tree seedlings to local groups."
            };

            Donation d13 = new Donation()
            {
                Title = "Children of Uganda",
                Price = 1000.00M,
                Partner = partner7,
                Plan = p3,
                Description = "Empowers African orphans living in extreme poverty to lead healthier lives."
            };

            Donation d14 = new Donation()
            {
                Title = "Water to Thrive",
                Price = 3000.00M,
                Partner = partner6,
                Plan = p1,
                Description = "Brings clean, safe water to rural African communities."
            };

            /*-----------------------------------------------------------------------*/



            Subscription s1 = new Subscription()
            {
                Title = "Voice of a Child U.S.",             
                Partner = partner1,
                Plan = p1,
                Description = "Help Infants Across the U.S."
            };


            Subscription s2 = new Subscription()
            {
                Title = "Help Juniata Community",
                Partner = partner1,
                Plan = p1,
                Description = "Fund Juniata Community Schools."
            };


            Subscription s3 = new Subscription()
            {
                Title = "Adopt a Hero",
                Partner = partner3,
                Plan = p1,
                Description = "Help Stray Dogs."
            };

            Subscription s4 = new Subscription()
            {
                Title = "Good Samaritans",
                Partner = partner5,
                Plan = p3,
                Description = "For the public benefit, the relief and assistance of people in need."
            };

            Subscription s5 = new Subscription()
            {
                Title = "Coalition for Veterans",
                Partner = partner2,
                Plan = p2,
                Description = "Help victims of war or natural disasters."
            };

            Subscription s6 = new Subscription()
            {
                Title = "Cancer Exam Network",
                Partner = partner6,
                Plan = p1,
                Description = "Help victims of war or natural disasters."
            };

            Subscription s7 = new Subscription()
            {
                Title = "Helping Hands",
                Partner = partner4,
                Plan = p2,
                Description = " To advance education in accordance with x principles."
            };


            Subscription s8 = new Subscription()
            {
                Title = "Power to Our Vets",
                Partner = partner7,
                Plan = p1,
                Description = "prevention or relief of poverty for the public benefit."
            };


            Subscription s9 = new Subscription()
            {
                Title = "H2O for Life",
                Partner = partner9,
                Plan = p1,
                Description = "Provides clean drinking water and sanitation to African schools through programs with U.S. schools."
            };

            Subscription s10 = new Subscription()
            {
                Title = "BEADS for Education",
                Partner = partner10,
                Plan = p2,
                Description = "Improves the status of Kenyan girls through education."
            };

            Subscription s11 = new Subscription()
            {
                Title = "Books For Africa",
                Partner = partner10,
                Plan = p2,
                Description = "This includes textbooks, library books, law libraries, and agricultural books in English and French."
            };

            Subscription s12 = new Subscription()
            {
                Title = "Trees for the Future",
                Partner = partner9,
                Plan = p3,
                Description = "Provides technical training, planning, and tree seedlings to local groups."
            };

            Subscription s13 = new Subscription()
            {
                Title = "Children of Uganda",
                Partner = partner7,
                Plan = p3,
                Description = "Empowers African orphans living in extreme poverty to lead healthier lives."
            };

            Subscription s14 = new Subscription()
            {
                Title = "Water to Thrive",
                Partner = partner6,
                Plan = p1,
                Description = "Brings clean, safe water to rural African communities."
            };

            /*-----------------------------------------------------------------------*/

            Product product1 = new Product() { Name = "Black Logo Tshirt", Price = 20M, Size = Size.L, ImageUrl = "/images/black.jpg" };
            Product product2 = new Product() { Name = "Blue Logo Tshirt", Price = 25M, Size = Size.M, ImageUrl = "/images/blue.jpg" };
            Product product3 = new Product() { Name = "Burgundy Logo Tshirt", Price = 15M, Size = Size.S, ImageUrl = "/images/bur.jpg" };
            Product product4 = new Product() { Name = "Black Logo Tshirt", Price = 18M, Size = Size.XL, ImageUrl = "/images/black.jpg" };
            Product product5 = new Product() { Name = "Blue Logo Tshirt", Price = 20M, Size = Size.L, ImageUrl = "/images/blue.jpg" };
            Product product6 = new Product() { Name = "Black Cause Tshirt", Price = 15M, Size = Size.XS, ImageUrl = "/images/ts.jpg" };
            Product product7 = new Product() { Name = "Black Cause Tshirt", Price = 15M, Size = Size.M, ImageUrl = "/images/ts.jpg" };
            Product product8 = new Product() { Name = "Black Cause Tshirt", Price = 15M, Size = Size.L, ImageUrl = "/images/ts.jpg" };

            /*-----------------------------------------------------------------------*/
            context.Products.AddOrUpdate(p => p.Name, product1, product2, product3, product4, product5, product6, product7, product8);
            context.SaveChanges();

            context.Plans.AddOrUpdate(p => p.Category, p1,p2,p3);
            context.SaveChanges();

            context.Partners.AddOrUpdate(p => p.Name, partner1,partner2, partner3, partner4, partner5, partner6, partner7, partner8, partner9, partner10);
            context.SaveChanges();

            context.Donations.AddOrUpdate(d => d.Title, d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,d13,d14);
            context.SaveChanges();

            context.Subscriptions.AddOrUpdate(s => s.Title, s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14);
            context.SaveChanges();

        }
    }
}
