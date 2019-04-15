namespace Assets.Script.StrangeIoc.model.Atoms
{
    public class Atom : IAtom {
        public Atom(int id, string atomName, string atomSymbol, string atomEnglishName, int atomNumber, double relativeAtomMass, string physicalProperty, string importantKnowledge, string atomIntroduction)
        {
            Id = id;
            AtomName = atomName;
            AtomSymbol = atomSymbol;
            AtomEnglishName = atomEnglishName;
            AtomNumber = atomNumber;
            RelativeAtomMass = relativeAtomMass;
            PhysicalProperty = physicalProperty;
            ImportantKnowledge = importantKnowledge;
            AtomIntroduction = atomIntroduction;
        }

        public int Id { get; set; }
        public string AtomName { get; set; }
        public string AtomSymbol { get; set; }
        public string AtomEnglishName { get; set; }
        public int AtomNumber { get; set; }
        public double RelativeAtomMass { get; set; }
        public string PhysicalProperty { get; set; }
        public string ImportantKnowledge { get; set; }
        public string AtomIntroduction { get; set; }

    }
}
