using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CREDITSUISSE_02.Application.Trade.Interfaces;
using CREDITSUISSE_02.Application.Trade.Services;
using CREDITSUISSE_03.Domain.Trade.Commands.Main;
using CREDITSUISSE_03.Domain.Trade.Events.Main;
using CREDITSUISSE_03.Domain.Trade.Handlers.Main;
using CREDITSUISSE_03.Domain.Trade.Interfaces;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_04.Core.Notifications;
using CREDITSUISSE_07.Bus;
using CREDITSUISSE_05.Data.Models.Trade.Repositories;

namespace CREDITSUISSE_06.Ioc
{
    public static class InversionOfControl
    {
        public static IServiceCollection AddInversionOfControlConfig(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            #region Trade
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<IRequestHandler<TradeCategorizeCommand, bool>, TradeCommandHandler>();

            services.AddScoped<INotificationHandler<TradeCategorizedEvent>, TradeEventHandler>();

            services.AddScoped<ITradeRepository, TradeRepository>();
            #endregion

            return services;
        }
    }
}