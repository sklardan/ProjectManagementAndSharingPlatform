namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DPSP_DAL.DboContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DPSP_DAL.DboContext context)
        {
            //to run uncomment code below
            addProjects(context);
            createRoles(context);
        }
        private void createRoles(DPSP_DAL.DboContext context)
        {
            var roles = context.Roles.ToDictionary(x => x.Enum, x => x.Id);
            context.Roles.AddRange(Enum.GetNames(typeof(RoleType)).Select(x => new Role()
            {
                Name = ((RoleType)Enum.Parse(typeof(RoleType), x)).GetDisplayName(),
                Enum = (RoleType)Enum.Parse(typeof(RoleType), x)
            }));
        }

    private void addProjects(DboContext context)
        {
            var projects = context.Projects.ToDictionary(x => x.Name, x => x.Id);
            context.Projects.AddRange(new List<Project>()
            {
                new Project() { Name = "TPM", Department = Department.Consulting, Client = "Deloitte Poland HR", Manager = "Pavel Sprynar", Employees = "Ivan Nevrela, Lukas Cibulka, Daniel Sklar", Introduction ="Internal application for evaluating Deloitte's employees", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum posuere erat vitae cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas nec justo tincidunt elit aliquam rutrum. Praesent in cursus nisi. Suspendisse in sem sodales, lacinia libero non, tincidunt ante. Pellentesque bibendum odio eu lacinia scelerisque. Nullam porta, erat sit amet accumsan venenatis, mauris mi fringilla lorem, eget malesuada lectus est nec mauris. Aliquam quis ornare lectus, a porttitor nisl. Praesent consectetur odio turpis, a ullamcorper nisl blandit nec. Proin elementum ut augue non consectetur. Ut interdum elit ut diam convallis scelerisque laoreet ut orci. Nunc fringilla egestas elit, ut ultrices elit. Mauris venenatis, felis pharetra sollicitudin interdum, neque nibh volutpat velit, et volutpat diam ligula vitae risus. Morbi ornare dignissim lobortis. Nam facilisis sodales neque, vel fringilla dolor rutrum sed. Quisque sit amet tincidunt massa. Maecenas accumsan in nunc et semper. Ut consectetur elit non lorem pellentesque, id iaculis diam luctus. Integer cursus in lectus ut bibendum. Nulla venenatis nulla sit amet vestibulum ultrices. Mauris egestas faucibus purus feugiat pulvinar. Suspendisse consectetur nunc nec felis iaculis, ac rhoncus augue sollicitudin. Nunc eu enim sem. Nunc efficitur a diam at porttitor. Suspendisse potenti. In at est eget erat pretium eleifend dictum vitae tellus. Fusce et lectus et eros imperdiet commodo. Maecenas pretium elit vel mauris malesuada, sit amet fermentum nunc finibus. Morbi euismod eros id enim viverra, sit amet fringilla nisl eleifend. Integer malesuada purus libero, eget finibus mauris tristique quis.", Conclusion ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt mi eu condimentum rutrum. Praesent et mauris eget libero ornare.", Budget="150 000 Euro", OpenDate= new DateTime(2016, 6, 1), CloseDate=new DateTime(2017, 6, 1) },
                new Project() { Name = "DPSP", Department = Department.Consulting, Client = "Deloitte Digital CZ", Manager = "Petr Viktora", Employees = "Ivan Nevrela, Lukas Cibulka, Daniel Sklar", Introduction ="Deloitte project sharing platform.", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum posuere erat vitae cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas nec justo tincidunt elit aliquam rutrum. Praesent in cursus nisi. Suspendisse in sem sodales, lacinia libero non, tincidunt ante. Pellentesque bibendum odio eu lacinia scelerisque. Nullam porta, erat sit amet accumsan venenatis, mauris mi fringilla lorem, eget malesuada lectus est nec mauris. Aliquam quis ornare lectus, a porttitor nisl. Praesent consectetur odio turpis, a ullamcorper nisl blandit nec. Proin elementum ut augue non consectetur. Ut interdum elit ut diam convallis scelerisque laoreet ut orci. Nunc fringilla egestas elit, ut ultrices elit. Mauris venenatis, felis pharetra sollicitudin interdum, neque nibh volutpat velit, et volutpat diam ligula vitae risus. Morbi ornare dignissim lobortis. Nam facilisis sodales neque, vel fringilla dolor rutrum sed. Quisque sit amet tincidunt massa. Maecenas accumsan in nunc et semper. Ut consectetur elit non lorem pellentesque, id iaculis diam luctus. Integer cursus in lectus ut bibendum. Nulla venenatis nulla sit amet vestibulum ultrices. Mauris egestas faucibus purus feugiat pulvinar. Suspendisse consectetur nunc nec felis iaculis, ac rhoncus augue sollicitudin. Nunc eu enim sem. Nunc efficitur a diam at porttitor. Suspendisse potenti. In at est eget erat pretium eleifend dictum vitae tellus. Fusce et lectus et eros imperdiet commodo. Maecenas pretium elit vel mauris malesuada, sit amet fermentum nunc finibus. Morbi euismod eros id enim viverra, sit amet fringilla nisl eleifend. Integer malesuada purus libero, eget finibus mauris tristique quis.", Conclusion ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt mi eu condimentum rutrum. Praesent et mauris eget libero ornare.", Budget="150 000 Euro", OpenDate= new DateTime(2016, 6, 1), CloseDate=null },
                new Project() { Name = "Koupelny Ptacek", Department = Department.Accounting, Client = "Ptacek s.r.o.", Manager = "Pavel Sprynar", Employees = "Ivan Nevrela, Lukas Cibulka, Daniel Sklar", Introduction ="Ptacek calculation of sales", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum posuere erat vitae cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas nec justo tincidunt elit aliquam rutrum. Praesent in cursus nisi. Suspendisse in sem sodales, lacinia libero non, tincidunt ante. Pellentesque bibendum odio eu lacinia scelerisque. Nullam porta, erat sit amet accumsan venenatis, mauris mi fringilla lorem, eget malesuada lectus est nec mauris. Aliquam quis ornare lectus, a porttitor nisl. Praesent consectetur odio turpis, a ullamcorper nisl blandit nec. Proin elementum ut augue non consectetur. Ut interdum elit ut diam convallis scelerisque laoreet ut orci. Nunc fringilla egestas elit, ut ultrices elit. Mauris venenatis, felis pharetra sollicitudin interdum, neque nibh volutpat velit, et volutpat diam ligula vitae risus. Morbi ornare dignissim lobortis. Nam facilisis sodales neque, vel fringilla dolor rutrum sed. Quisque sit amet tincidunt massa. Maecenas accumsan in nunc et semper. Ut consectetur elit non lorem pellentesque, id iaculis diam luctus. Integer cursus in lectus ut bibendum. Nulla venenatis nulla sit amet vestibulum ultrices. Mauris egestas faucibus purus feugiat pulvinar. Suspendisse consectetur nunc nec felis iaculis, ac rhoncus augue sollicitudin. Nunc eu enim sem. Nunc efficitur a diam at porttitor. Suspendisse potenti. In at est eget erat pretium eleifend dictum vitae tellus. Fusce et lectus et eros imperdiet commodo. Maecenas pretium elit vel mauris malesuada, sit amet fermentum nunc finibus. Morbi euismod eros id enim viverra, sit amet fringilla nisl eleifend. Integer malesuada purus libero, eget finibus mauris tristique quis.", Conclusion ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt mi eu condimentum rutrum. Praesent et mauris eget libero ornare.", Budget="150 000 Euro", OpenDate= new DateTime(2016, 6, 1), CloseDate=new DateTime(2018, 6, 1) },
                new Project() { Name = "Banking design", Department = Department.Law, Client = "CSOB", Manager = "Johan Strauss", Employees = "Ivan Nevrela, Lukas Cibulka, Daniel Sklar", Introduction ="Study of banking processes in Europe.", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum posuere erat vitae cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas nec justo tincidunt elit aliquam rutrum. Praesent in cursus nisi. Suspendisse in sem sodales, lacinia libero non, tincidunt ante. Pellentesque bibendum odio eu lacinia scelerisque. Nullam porta, erat sit amet accumsan venenatis, mauris mi fringilla lorem, eget malesuada lectus est nec mauris. Aliquam quis ornare lectus, a porttitor nisl. Praesent consectetur odio turpis, a ullamcorper nisl blandit nec. Proin elementum ut augue non consectetur. Ut interdum elit ut diam convallis scelerisque laoreet ut orci. Nunc fringilla egestas elit, ut ultrices elit. Mauris venenatis, felis pharetra sollicitudin interdum, neque nibh volutpat velit, et volutpat diam ligula vitae risus. Morbi ornare dignissim lobortis. Nam facilisis sodales neque, vel fringilla dolor rutrum sed. Quisque sit amet tincidunt massa. Maecenas accumsan in nunc et semper. Ut consectetur elit non lorem pellentesque, id iaculis diam luctus. Integer cursus in lectus ut bibendum. Nulla venenatis nulla sit amet vestibulum ultrices. Mauris egestas faucibus purus feugiat pulvinar. Suspendisse consectetur nunc nec felis iaculis, ac rhoncus augue sollicitudin. Nunc eu enim sem. Nunc efficitur a diam at porttitor. Suspendisse potenti. In at est eget erat pretium eleifend dictum vitae tellus. Fusce et lectus et eros imperdiet commodo. Maecenas pretium elit vel mauris malesuada, sit amet fermentum nunc finibus. Morbi euismod eros id enim viverra, sit amet fringilla nisl eleifend. Integer malesuada purus libero, eget finibus mauris tristique quis.", Conclusion ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt mi eu condimentum rutrum. Praesent et mauris eget libero ornare.", Budget="150 000 Euro", OpenDate= new DateTime(2016, 6, 1), CloseDate=null },
                new Project() { Name = "Chatbot", Department = Department.Taxes, Client = "Facebook", Manager = "Emanuel Bach", Employees = "Ivan Nevrela, Lukas Cibulka, Daniel Sklar", Introduction ="Cahtbot for comunicating in messenger.", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum posuere erat vitae cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas nec justo tincidunt elit aliquam rutrum. Praesent in cursus nisi. Suspendisse in sem sodales, lacinia libero non, tincidunt ante. Pellentesque bibendum odio eu lacinia scelerisque. Nullam porta, erat sit amet accumsan venenatis, mauris mi fringilla lorem, eget malesuada lectus est nec mauris. Aliquam quis ornare lectus, a porttitor nisl. Praesent consectetur odio turpis, a ullamcorper nisl blandit nec. Proin elementum ut augue non consectetur. Ut interdum elit ut diam convallis scelerisque laoreet ut orci. Nunc fringilla egestas elit, ut ultrices elit. Mauris venenatis, felis pharetra sollicitudin interdum, neque nibh volutpat velit, et volutpat diam ligula vitae risus. Morbi ornare dignissim lobortis. Nam facilisis sodales neque, vel fringilla dolor rutrum sed. Quisque sit amet tincidunt massa. Maecenas accumsan in nunc et semper. Ut consectetur elit non lorem pellentesque, id iaculis diam luctus. Integer cursus in lectus ut bibendum. Nulla venenatis nulla sit amet vestibulum ultrices. Mauris egestas faucibus purus feugiat pulvinar. Suspendisse consectetur nunc nec felis iaculis, ac rhoncus augue sollicitudin. Nunc eu enim sem. Nunc efficitur a diam at porttitor. Suspendisse potenti. In at est eget erat pretium eleifend dictum vitae tellus. Fusce et lectus et eros imperdiet commodo. Maecenas pretium elit vel mauris malesuada, sit amet fermentum nunc finibus. Morbi euismod eros id enim viverra, sit amet fringilla nisl eleifend. Integer malesuada purus libero, eget finibus mauris tristique quis.", Conclusion ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt mi eu condimentum rutrum. Praesent et mauris eget libero ornare.", Budget="150 000 Euro", OpenDate= new DateTime(2016, 6, 1), CloseDate=null },
                new Project() { Name = "Driving cars", Department = Department.Consulting, Client = "Skoda Auto", Manager = "Johnny Cage", Employees = "Ivan Nevrela, Lukas Cibulka, Daniel Sklar", Introduction ="Study of car sales in Czech Republic", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum posuere erat vitae cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas nec justo tincidunt elit aliquam rutrum. Praesent in cursus nisi. Suspendisse in sem sodales, lacinia libero non, tincidunt ante. Pellentesque bibendum odio eu lacinia scelerisque. Nullam porta, erat sit amet accumsan venenatis, mauris mi fringilla lorem, eget malesuada lectus est nec mauris. Aliquam quis ornare lectus, a porttitor nisl. Praesent consectetur odio turpis, a ullamcorper nisl blandit nec. Proin elementum ut augue non consectetur. Ut interdum elit ut diam convallis scelerisque laoreet ut orci. Nunc fringilla egestas elit, ut ultrices elit. Mauris venenatis, felis pharetra sollicitudin interdum, neque nibh volutpat velit, et volutpat diam ligula vitae risus. Morbi ornare dignissim lobortis. Nam facilisis sodales neque, vel fringilla dolor rutrum sed. Quisque sit amet tincidunt massa. Maecenas accumsan in nunc et semper. Ut consectetur elit non lorem pellentesque, id iaculis diam luctus. Integer cursus in lectus ut bibendum. Nulla venenatis nulla sit amet vestibulum ultrices. Mauris egestas faucibus purus feugiat pulvinar. Suspendisse consectetur nunc nec felis iaculis, ac rhoncus augue sollicitudin. Nunc eu enim sem. Nunc efficitur a diam at porttitor. Suspendisse potenti. In at est eget erat pretium eleifend dictum vitae tellus. Fusce et lectus et eros imperdiet commodo. Maecenas pretium elit vel mauris malesuada, sit amet fermentum nunc finibus. Morbi euismod eros id enim viverra, sit amet fringilla nisl eleifend. Integer malesuada purus libero, eget finibus mauris tristique quis.", Conclusion ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt mi eu condimentum rutrum. Praesent et mauris eget libero ornare.", Budget="150 000 Euro", OpenDate= new DateTime(2016, 6, 1), CloseDate=null },
            });
        }

    }
    }
