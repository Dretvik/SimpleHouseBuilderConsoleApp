using System.Diagnostics;

namespace HouseBuilderConsoleApp
{
    internal class HouseBuilder
    {
        private House house = new House();
        private Room room;
        private int currentFloorIndex = 0;
        private int currentRoomCount = 0;
        private int currentBathroomCount = 0;
        private int currentKitchenCount = 0;

        internal void AddRoom()
        {
            while (true)
            {
                try
                {
                    PrintHouseInfo();
                    Console.WriteLine("\n1. Add Bathroom \n2. Add Kitchen \n3. Add Bedroom \n4. Add Living Room");
                    Console.WriteLine("\n0. Go back to main menu..");
                    string choice = Console.ReadLine();


                    if (currentRoomCount >= 5)
                    {
                        currentFloorIndex++;
                        currentRoomCount = 0;
                        currentBathroomCount = 0;
                        currentKitchenCount = 0;
                    }

                    if (currentRoomCount < 5)
                    {
                        string roomType;

                        switch (choice)
                        {
                            case "1":
                                Console.Clear();
                                room = new Bathroom();
                                roomType = room.Type;
                                break;
                            case "2":
                                Console.Clear();
                                room = new Kitchen();
                                roomType = room.Type;
                                break;
                            case "3":
                                Console.Clear();
                                room = new Bedroom();
                                roomType = room.Type;
                                break;
                            case "4":
                                Console.Clear();
                                room = new Livingroom();
                                roomType = room.Type;
                                break;
                            case "0":
                                Console.Clear();
                                return;
                            default:
                                throw new InvalidOperationException($"Unknown room choice: {choice}");
                        }

                        if (CanAddRoom(roomType))
                        {
                            if (house.Floors.Count <= currentFloorIndex)
                            {
                                house.Floors.Add(new Floor());
                            }

                            house.Floors[currentFloorIndex].Rooms.Add(room);
                            currentRoomCount++;

                            UpdateRoomCounts(roomType);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Cannot add more {roomType} to the current floor.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Each floor can't have more than 5 rooms.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
        private void UpdateRoomCounts(string roomType)
        {
            switch (roomType.ToLower())
            {
                case "bathroom":
                    currentBathroomCount++;
                    break;
                case "kitchen":
                    currentKitchenCount++;
                    break;
            }
        }

        private bool CanAddRoom(string roomType)
        {
            switch (roomType.ToLower())
            {
                case "bathroom":
                    return currentBathroomCount == 0;
                case "kitchen":
                    return currentKitchenCount == 0;
                case "bedroom":
                case "livingroom":
                    return currentRoomCount < 5;
                default:
                    throw new InvalidOperationException($"Unknown room type: {roomType}");
            }
        }


        internal bool IsHouseComplete()
        {
            if (house.Floors.Count >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal void PrintHouseInfo()
        {
            Console.WriteLine("Information about the rooms of your house:");
            for (int i = 0; i < house.Floors.Count; i++)
            {
                Console.WriteLine($"\nFloor number {i + 1}:");
                foreach (var room in house.Floors[i].Rooms)
                {
                    Console.WriteLine($" - {room.Type}");
                }
            }
        }
    }
}
