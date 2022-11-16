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

        // GET BY ID
        public async Task<IBaseResponse<Note>> GetNote(int id)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                var note = await _noteRepository.Get(id);
                if (note == null)
                {
                    baseResponse.Description = "Note not found.";
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
        
        //GET BY NAME
        public async Task<IBaseResponse<Note>> GetNoteByName (string name)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                var note = await _noteRepository.GetByName(name);
                if (note == null)
                {
                    baseResponse.Description = "Note not found.";
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
                    Description = $"[GetNotesByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Note>> EditNote(int id, Note note)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                note = await _noteRepository.Get(id);
                if (note == null)
                {
                    baseResponse.StatusCode = StatusCode.NoteNotFound;
                    baseResponse.Description = "Note not found.";
                    return baseResponse;
                }

                note.Name = note.Name;
                note.Description = note.Description;
                note.ColorHex = note.ColorHex;
                note.DateCreated = note.DateCreated;
                note.NotesType = note.NotesType;

                await _noteRepository.Update(note);

                return baseResponse;
            }
            catch (Exception ex)
            { 
                return new BaseResponse<Note>()
                {
                    Description = $"[EditNote] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        // CREATE NOTE
        public async Task<IBaseResponse<Note>> CreateNote(Note note)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                note = new Note()
                {
                    Name = note.Name,
                    Description = note.Description,
                    ColorHex = (ColorHex)Convert.ToInt32(note.ColorHex),
                    DateCreated = note.DateCreated,
                    NotesType = (NotesType)Convert.ToInt32(note.NotesType)
                };

                await _noteRepository.Create(note);

            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"[CreateNote] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        // DELETE NOTE
        public async Task<IBaseResponse<bool>> DeleteNote(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var note = await _noteRepository.Get(id);
                if (note == null)
                {
                    baseResponse.Description = "Note not found.";
                    baseResponse.StatusCode = StatusCode.NoteNotFound;
                    return baseResponse;
                }

                await _noteRepository.Delete(note);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteNote] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        // GET THE LIST OF NOTES (SELECT)
        public async Task<IBaseResponse<IEnumerable<Note>>> GetNotes()
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