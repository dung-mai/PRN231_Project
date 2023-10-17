namespace Repository.IRepository
{
    public interface IDetailScoreRepository
    {
        List<DetailScoreDTO> FillIdAndCommentData(List<DetailScoreDTO> detailScores, int classId, int itemId);
        bool AddOrUpdateScore(List<DetailScoreDTO> detailScores);
    }
}