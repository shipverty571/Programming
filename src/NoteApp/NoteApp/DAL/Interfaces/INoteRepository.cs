using NoteApp.Domain.Entity;

namespace NoteApp.DAL.Interfaces;

public interface INoteRepository
{
    public Task Create(NoteEntity note);

    public IQueryable<NoteEntity> GetAll();

    public Task Update(NoteEntity note);

    public Task Delete(NoteEntity note);
}