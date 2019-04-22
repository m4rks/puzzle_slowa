using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Puzzle.Zdania.IServices;
using Puzzle.Zdania.MockServices;
using Puzzle.Zdania.WPFClient;
//https://en.wikipedia.org/wiki/Service_locator_pattern
namespace Puzzle.Zdania.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            UseAutoFac();
        }

        private void UseAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MockSatzeService>().As<ISatzeService>();
            builder.RegisterType<PuzzleService>().As<IPuzzleService>();
            builder.RegisterType<TimerService>().SingleInstance();

            builder.RegisterType<ShellViewModel>();
            builder.RegisterType<PuzzleZdaniaViewModel>().SingleInstance();
            builder.RegisterType<ListOfTasksViewModel>().SingleInstance();

            builder.RegisterType<FrameNavigationService>().As<INavigationService>().SingleInstance();

            IContainer container = builder.Build();

            // Install-Package Autofac.Extras.CommonServiceLocator
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

        }

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public ListOfTasksViewModel ListOfTasksViewModel => ServiceLocator.Current.GetInstance<ListOfTasksViewModel>();
        public PuzzleZdaniaViewModel PuzzleZdaniaViewModel => ServiceLocator.Current.GetInstance<PuzzleZdaniaViewModel>();

    }
}
