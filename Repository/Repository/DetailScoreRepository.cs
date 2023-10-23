using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.Request.DetailScore;
using DTO.Response.DetailScore;
using Repository.IRepository;

namespace Repository.Repository
{
    public class DetailScoreRepository : IDetailScoreRepository
    {
        DetailScoreDAO detailScoreDAO;
        IMapper _mapper;

        public DetailScoreRepository(FAPDbContext context, IMapper mapper)
        {
            detailScoreDAO = new DetailScoreDAO(context);
            _mapper = mapper;
        }

        public List<DetailScoreResponseDTO> FillIdAndCommentData(List<DetailScoreResponseDTO> detailScores, int classId, int itemId)
        {
            //foreach (var detailScoreInput in detailScores)
            //{
            //    DetailScore? score = detailScoreDAO.FindScore((!String.IsNullOrEmpty(detailScoreInput.Rollnumber) ? detailScoreInput.Rollnumber : ""), classId, itemId);
            //    if (score != null)
            //    {
            //        detailScoreInput.Id = score.Id;
            //        detailScoreInput.Comment = score.Comment;
            //    }
            //}
            //return detailScores;
            throw new NotImplementedException();
        }

        public bool AddOrUpdateScore(List<DetailScoreResponseDTO> detailScores)
        {

            //foreach (var detailScoreInput in detailScores)
            //{
            //    detailScoreDAO.AddOrUpdateScore(_mapper.Map<DetailScore>(detailScoreInput));
            //}
            //return true;
            throw new NotImplementedException();
        }

        public bool AddDetailScore(DetailScoreAddDTO detailScore)
        {
            return detailScoreDAO.AddDetailScore(_mapper.Map<DetailScore>(detailScore));
        }

        public DetailScoreResponseDTO? GetDetailScoreById(int id)
        {
            return _mapper.Map<DetailScoreResponseDTO>(detailScoreDAO.GetGetDetailScoreById(id));
        }

        public bool DeleteDetailScore(DetailScoreUpdateDTO detailScore)
        {
            return detailScoreDAO.DeleteDetailScore(_mapper.Map<DetailScore>(detailScore));
        }

        public bool UpdateDetailScore(DetailScoreUpdateDTO detailScore)
        {
            return detailScoreDAO.UpdateDetailScore(_mapper.Map<DetailScore>(detailScore));
        }

        public List<DetailScoreResponseDTO> GetDetailScores()
        {
            return _mapper.Map<List<DetailScoreResponseDTO>>(detailScoreDAO.GetDetailScores());
        }
    }
}
