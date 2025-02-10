using AutoMapper;
using LibraryManagement.Database.Common.Repository;
using LibraryManagement.Database.Common.Service;
using LibraryManagement.Database.Common.UnitOfWork;
using LibraryManagement.Dtos.IssueBook;
using LibraryManagement.Dtos.Issuer;
using LibraryManagement.Models;

namespace LibraryManagement.Database.Service
{
    public class IssuerService : Service<Issuer, LibraryDbContext>, IIssuerService
    {
        private readonly IRepository<Issuer, LibraryDbContext> repository;
        private readonly IUnitOfWork<LibraryDbContext> unitOfWork;
        private readonly IMapper mapper;

        public IssuerService(IRepository<Issuer, LibraryDbContext> repository, IUnitOfWork<LibraryDbContext> unitOfWork, IMapper mapper) : base(repository)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IssuerDto>> GetAllAsync()
        {
            var issuers = await repository.GetAllAsync();
            var issuerToDto = mapper.Map<IEnumerable<IssuerDto>>(issuers);
            return issuerToDto;
        }

        public async Task<IssuerDto> GetByIdAsync(int id)
        {
            var issuers = await repository.GetByIdAsync(id);
            var issuerToDto = mapper.Map<IssuerDto>(issuers);
            return issuerToDto;
        }

        public async Task<bool> CreateAsync(CreateIssuerDto createIssuerDto)
        {
            try
            {
                var issuer = mapper.Map<Issuer>(createIssuerDto);
                issuer.MembershipExpireDate = new DateTime().Add(TimeSpan.FromDays(30));
                repository.Add(issuer);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
