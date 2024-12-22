﻿namespace UniversiteDomain.Entities;

public class Ue
{
    public long Id { get; set; }
    public string NumeroUe { get; set; } = String.Empty;
    public string Intitule { get; set; } = String.Empty;
    // ManyToMany : une Ue est enseignée dnas plusieurs parcours
    public List<Parcours>? EnseigneeDans { get; set; } = new();
    
    //ManyToMany : une Ue a plusieurs notes
    public List<Note>? Notes { get; set; } = new();
    public Parcours Parcours { get; set; }

    public override string ToString()
    {
        return "ID "+Id +" : "+NumeroUe+" - "+Intitule;
    }
}