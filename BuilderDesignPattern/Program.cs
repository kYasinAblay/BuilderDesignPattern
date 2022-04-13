using System;

namespace BuilderDesignPattern
{

    public class House
    {
        private String basement;
        private String structure;
        private String roof;
        private String interior;

        public void setBasement(String basement)
        {
            this.basement = basement;
        }

        public void setStructure(String structure)
        {
            this.structure = structure;
        }

        public void setRoof(String roof)
        {
            this.roof = roof;
        }

        public void setInterior(String interior)
        {
            this.interior = interior;
        }
        public override string ToString()
        {
            return $"{basement} is create.\n{structure} is create\n{roof} is create.\n{interior} is create";
        }
    }

    //Builder class
    interface IHouseBuilder
    {
        public void buildBasement();
        public void buildStructure();
        public void bulidRoof();
        public void buildInterior();
        public House getHouse();

    }

    //Concrete Builder class
    class IglooHouseBuilder : IHouseBuilder
    {
        private House house;

        public IglooHouseBuilder()
        {
            this.house = new House();
        }

        public void buildBasement()
        {
            house.setBasement("Ice Bars");
        }

        public void buildStructure()
        {
            house.setStructure("Ice Blocks");
        }

        public void buildInterior()
        {
            house.setInterior("Ice Carvings");
        }

        public void bulidRoof()
        {
            house.setRoof("Ice Dome");
        }

        public House getHouse()
        {
            return this.house;
        }

    }

    //Concrete Builder class
    class TipiHouseBuilder : IHouseBuilder
    {
        private House house;

        public TipiHouseBuilder()
        {
            this.house = new House();
        }

        public void buildBasement()
        {
            house.setBasement("Wooden Poles");
        }

        public void buildStructure()
        {
            house.setStructure("Wood and Ice");
        }

        public void buildInterior()
        {
            house.setInterior("Fire Wood");
        }

        public void bulidRoof()
        {
            house.setRoof("Wood, caribou and seal skins");
        }

        public House getHouse()
        {
            return this.house;
        }

    }

    //Director class
    class CivilEngineer
    {
        private IHouseBuilder houseBuilder;

        public House getHouse()
        {
            return this.houseBuilder.getHouse();
        }

        public void constructHouse(IHouseBuilder houseBuilder)
        {
            houseBuilder.buildBasement();
            houseBuilder.buildStructure();
            houseBuilder.bulidRoof();
            houseBuilder.buildInterior();

            this.houseBuilder = houseBuilder;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IHouseBuilder iglooBuilder = new IglooHouseBuilder();
            CivilEngineer engineer = new CivilEngineer();
            engineer.constructHouse(iglooBuilder);

            House house = engineer.getHouse();

            Console.WriteLine("Builder constructed: " + house);

        }
    }

}



