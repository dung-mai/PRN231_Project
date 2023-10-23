﻿using DTO.Request.DetailScore;
using DTO.Response.DetailScore;

namespace Repository.IRepository
{
    public interface IDetailScoreRepository
    {

        bool AddDetailScore(DetailScoreAddDTO detailScore);
        DetailScoreResponseDTO? GetDetailScoreById(int id);
        bool DeleteDetailScore(DetailScoreUpdateDTO detailScore);
        bool UpdateDetailScore(DetailScoreUpdateDTO detailScore);
        List<DetailScoreResponseDTO> GetDetailScores();

        List<DetailScoreResponseDTO> FillIdAndCommentData(List<DetailScoreResponseDTO> detailScores, int classId, int itemId);
        bool AddOrUpdateScore(List<DetailScoreResponseDTO> detailScores);
    }
}