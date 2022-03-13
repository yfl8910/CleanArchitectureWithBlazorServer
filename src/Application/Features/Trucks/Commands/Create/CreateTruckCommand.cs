// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Trucks.DTOs;

namespace CleanArchitecture.Blazor.Application.Features.Trucks.Commands.Create;

    public class CreateTruckCommand: TruckDto,IRequest<Result<int>>, IMapFrom<Truck>
    {
       
    }
    
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateTruckCommand> _localizer;
        public CreateTruckCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<CreateTruckCommand> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
           var item = _mapper.Map<Truck>(request);
           _context.Trucks.Add(item);
           await _context.SaveChangesAsync(cancellationToken);
           return  Result<int>.Success(item.Id);
        }
    }

