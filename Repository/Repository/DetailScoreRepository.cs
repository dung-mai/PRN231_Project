using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using Repository.IRepository;

namespace Repository.Repository
{
    public class DetailScoreRepository : IDetailScoreRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public DetailScoreRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DetailScoreDTO> FillIdAndCommentData(List<DetailScoreDTO> detailScores, int classId, int itemId)
        {
            DetailScoreDAO detailScoreDAO = new DetailScoreDAO(_context);
            foreach (var detailScoreInput in detailScores)
            {
                DetailScore? score = detailScoreDAO.FindScore((!String.IsNullOrEmpty(detailScoreInput.Rollnumber) ? detailScoreInput.Rollnumber : ""), classId, itemId);
                if (score != null)
                {
                    detailScoreInput.Id = score.Id;
                    detailScoreInput.Comment = score.Comment;
                }
            }
            return detailScores;
        }

        public bool AddOrUpdateScore(List<DetailScoreDTO> detailScores)
        {
            DetailScoreDAO detailScoreDAO = new DetailScoreDAO(_context);
            foreach (var detailScoreInput in detailScores)
            {
                detailScoreDAO.AddOrUpdateScore(_mapper.Map<DetailScore>(detailScoreInput));
            }
            _context.SaveChanges();
            return true;
        }
    }
}
