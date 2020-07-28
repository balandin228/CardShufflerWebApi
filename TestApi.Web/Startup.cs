using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TestApi.Core;
using Microsoft.EntityFrameworkCore;
using TestApi.Core.DeckBuilder;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;
using TestApi.Core.Infrastructure;
using TestApi.Core.Shuffler;
using TestApi.Web.Dtos;

namespace TestApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvcCore();
            services.AddDbContext<TestApiDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TestApiDbContext"),
                x => x.MigrationsAssembly(typeof(Card).Assembly.FullName)));
            services.RegisterAllRepository();
            services.AddTransient<IDeckBuilder, DeckBuilder>();
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Card, CardDto>();
                cfg.CreateMap<CardInDeck, CardDto>()
                    .ForMember(x => x.Suit,
                        opt => opt.MapFrom(x => x.Card.Suit))
                    .ForMember(x=>x.Rank,
                        opt=>opt.MapFrom(x=>x.Card.Rank));
                cfg.CreateMap<Deck, DeckDto>()
                    .ForMember(x => x.Id, 
                        opt => opt.MapFrom(x => x.Key))
                    .ForMember(x => x.Card,
                        opt => opt
                            .MapFrom((deck, deckDto, i, context) => deck.CardInDecks
                                .OrderBy(cd => cd.NumberInDeck)
                                .Select(c => context.Mapper.Map<CardDto>(c))));
                cfg.CreateMap<Deck, GetDecksDto>()
                    .ForMember(x => x.Id,
                        opt => opt.MapFrom(x => x.Key));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Api V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
