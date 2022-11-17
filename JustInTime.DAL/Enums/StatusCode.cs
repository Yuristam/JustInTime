namespace JustInTime.Domain.Enums
{

    public enum StatusCode
    {
        // Status Codes for Notes
        NoteNotFound = 0,
        
        // User errors
        
        
        // Everything is working ok!
        OK = 200,
        
        // Internal Errors
        InternalServerError = 500,
        PageNotFound = 404,

    }
}