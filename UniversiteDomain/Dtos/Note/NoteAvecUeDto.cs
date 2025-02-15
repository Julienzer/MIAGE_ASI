using UniversiteDomain.Entities;

namespace UniversiteDomain.Dtos;

public class NoteAvecUeDto
{
    public long EtudiantId { get; set; }
    public long UeId { get; set; }
    public float Valeur { get; set; }

    public NoteAvecUeDto ToDto(Note note)
    {
        EtudiantId = note.IdEtudiant;
        UeId = note.IdUe;
        Valeur = note.Valeur;
        return this;
    }
    
    public Note ToEntity()
    {
        return new Note {IdEtudiant = this.EtudiantId, IdUe = this.UeId, Valeur = this.Valeur};
    }
    
    public List<NoteAvecUeDto> ToDtos(List<Note> notes)
    {
        List<NoteAvecUeDto> dtos = new();
        foreach (var note in notes)
        {
            dtos.Add(new NoteAvecUeDto().ToDto(note));
        }
        return dtos;
    }

    public List<Note> ToEntities(List<NoteAvecUeDto> noteDtos)
    {
        List<Note> notes = new();
        foreach (NoteAvecUeDto noteDto in noteDtos)
        {
            notes.Add(noteDto.ToEntity());
        }

        return notes;
    }
}