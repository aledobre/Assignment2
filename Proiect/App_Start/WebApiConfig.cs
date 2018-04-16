using Proiect.bll;
using Proiect.bll.Contracts;
using Proiect.bll.Mappers;
using Proiect.bll.Services;
using Proiect.Contracts;
using Proiect.dal.Contracts;
using Proiect.dal.Repositories;
using Proiect.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Proiect
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<IStudentService, StudentService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudentMapper, StudentMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudentAPIMapper, StudentAPIMapper>(new HierarchicalLifetimeManager());

            container.RegisterType<ILaboratoryRepository, LaboratoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILaboratoryMapper, LaboratoryMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<ILaboratoryService, LaboratoryService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILaboratoryAPIMapper, LaboratoryAPIMapper>(new HierarchicalLifetimeManager());

            container.RegisterType<IAttendanceRepository, AttendanceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAttendanceMapper, AttendanceMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAttendanceService, AttendanceService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAttendanceAPIMapper, AttendanceAPIMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAttendanceAPIShortMapper, AttendanceAPIShortMapper>(new HierarchicalLifetimeManager());

            container.RegisterType<IAssignmentRepository, AssignmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAssignmentMapper, AssignmentMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAssignmentService, AssignmentService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAssignmentAPIMapper, AssignmentAPIMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAssignmentAPIShortMapper, AssignmentAPIShortMapper>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
