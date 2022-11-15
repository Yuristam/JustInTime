using JustInTime.Domain.Entities;
using JustInTime.Domain.Responses;
using JustInTime.BLL.ServiceInterfaces;
using JustInTime.DAL.Interfaces;
using JustInTime.Domain.Enums;

namespace JustInTime.BLL.Implementations
{

    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IBaseResponse<Note>> GetNote(int id)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                var note = await _noteRepository.Get(id);
                if (note == null)
                {
                    baseResponse.Description = "This note doesn't exist!";
                    baseResponse.StatusCode = StatusCode.NoteNotFound;
                    return baseResponse;
                }

                baseResponse.Data = note;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"[GetNotes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Note>>> GetAllNotes()
        {
            var baseResponse = new BaseResponse<IEnumerable<Note>>();
            try
            {
                var notes = await _noteRepository.Select();
                if (notes.Count == 0)
                {
                    baseResponse.Description = "Found 0 elements.";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = notes;
                baseResponse.StatusCode = StatusCode.OK;
                
                
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Note>>()
                {
                    Description = $"[GetNotes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}