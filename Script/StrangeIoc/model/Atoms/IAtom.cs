namespace Assets.Script.StrangeIoc.model.Atoms
{
    public interface IAtom
    {
        int Id { get; set; }
        string AtomName { get; set; }
        string AtomSymbol { get; set; }
        string AtomEnglishName { get; set; }
        int AtomNumber { get; set; }
        double RelativeAtomMass { get; set; }
        string PhysicalProperty { get; set; }
        string ImportantKnowledge { get; set; }
        string AtomIntroduction { get; set; }

    }
}
