using System;
using System.Xml.Serialization;
using Domain;
using MediatR;
using Persistance;
using AutoMapper;

namespace Application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Activity.ID], cancellationToken)
                            ?? throw new Exception("Activity cannot be found");

            mapper.Map(request.Activity, activity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
