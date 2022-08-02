using AccessoryOptimizer.Models;


Main();

void Main()
{
    bool workOutNecklace = false;
    if(workOutNecklace)
    {
        WorkoutNecklace();
    }

    bool workOutEarring = true;

    if(workOutEarring)
    {
        WorkoutEarring();
    }
}

void WorkoutNecklace()
{
    byte[] necklaceBytes = GetNecklaceData();
    necklaceBytes = RemoveFromByteArray(necklaceBytes, 14);

    byte[] buyout = GetValue(35000);
    byte[] bid = GetValue(26250);

    byte[] engraving1 = GetValue((int)EngravingType.Adrenaline);
    byte[] engraving1Quantity = GetValue(5);

    byte[] engraving2 = GetValue((int)EngravingType.Hit_Master);
    byte[] engraving2Quantity = GetValue(3);

    byte[] statType1 = GetValue((int)Stat_Type.Crit);
    byte[] statType1Quantity = GetValue(475);

    byte[] statType2 = GetValue((int)Stat_Type.Specialization);
    byte[] statType2Quantity = GetValue(500);

    byte[] negativeEngravingType = GetValue((int)EngravingType.Atk_Power_Reduction);
    byte[] negativeEngravingQuantity = GetValue(3);

    byte[] itemId = GetValue(213300030);

    var buyout_byteToStart = Search(necklaceBytes, buyout.Reverse().ToArray());
    Console.WriteLine($"Buyout: {buyout_byteToStart}");
    var bid_byteToStart = Search(necklaceBytes, bid.Reverse().ToArray());
    Console.WriteLine($"Bid: {bid_byteToStart}");

    var engraving1_byteToStart = Search(necklaceBytes, engraving1.Reverse().ToArray());
    var engraving1Quantity_byteToStart = engraving1_byteToStart + 5;
    Console.WriteLine($"Engraving Type 1: {engraving1_byteToStart}");
    Console.WriteLine($"Engraving Quantity 1: {engraving1Quantity_byteToStart}");

    var engraving2_byteToStart = Search(necklaceBytes, engraving2.Reverse().ToArray());
    var engraving2Quantity_byteToStart = engraving2_byteToStart + 5;
    Console.WriteLine($"Engraving Type 2: {engraving2_byteToStart}");
    Console.WriteLine($"Engraving Quantity 2: {engraving2Quantity_byteToStart}");

    var statType1_byteToStart = Search(necklaceBytes, statType1.Reverse().ToArray());
    var statType1Quantity_byteToStart = Search(necklaceBytes, statType1Quantity.Reverse().ToArray());
    Console.WriteLine($"Stat Type 1: {statType1_byteToStart}");
    Console.WriteLine($"Stat Quantity 1: {statType1Quantity_byteToStart}");

    var statType2_byteToStart = Search(necklaceBytes, statType2.Reverse().ToArray());
    var statType2Quantity_byteToStart = Search(necklaceBytes, statType2Quantity.Reverse().ToArray());
    Console.WriteLine($"Stat Type 2: {statType2_byteToStart}");
    Console.WriteLine($"Stat Quantity 2: {statType2Quantity_byteToStart}");

    var negativeEngravingType_byteToStart = Search(necklaceBytes, negativeEngravingType.Reverse().ToArray());
    var negativeEngravingQuantity_byteToStart = negativeEngravingType_byteToStart + 9;
    Console.WriteLine($"Neg Engraving Type: {negativeEngravingType_byteToStart}");
    Console.WriteLine($"Neg Engraving Quantity: {negativeEngravingQuantity_byteToStart}");

    var itemId_byteToStart = Search(necklaceBytes, itemId.Reverse().ToArray());
    Console.WriteLine($"Item ID: {itemId_byteToStart}");
}

void WorkoutEarring()
{
    byte[] earringBytes = GetEarringData();
    //earringBytes = RemoveFromByteArray(earringBytes, 14);

    byte[] buyout = GetValue(100);
    byte[] bid = GetValue(50);

    byte[] engraving1 = GetValue((int)EngravingType.Sight_Focus);
    byte[] engraving1Quantity = GetValue(5);

    byte[] engraving2 = GetValue((int)EngravingType.Hit_Master);
    byte[] engraving2Quantity = GetValue(3);

    byte[] statType1 = GetValue((int)Stat_Type.Swiftness);
    byte[] statType1Quantity = GetValue(295);

    byte[] negativeEngravingType = GetValue((int)EngravingType.Move_Speed_Reduction);
    byte[] negativeEngravingQuantity = GetValue(2);

    byte[] itemId = GetValue(213300041);

    var buyout_byteToStart = Search(earringBytes, buyout.Reverse().ToArray());
    Console.WriteLine($"Buyout: {buyout_byteToStart}");
    var bid_byteToStart = Search(earringBytes, bid.Reverse().ToArray());
    Console.WriteLine($"Bid: {bid_byteToStart}");

    var engraving1_byteToStart = Search(earringBytes, engraving1.Reverse().ToArray());
    var engraving1Quantity_byteToStart = engraving1_byteToStart + 5;
    Console.WriteLine($"Engraving Type 1: {engraving1_byteToStart}");
    Console.WriteLine($"Engraving Quantity 1: {engraving1Quantity_byteToStart}");

    var engraving2_byteToStart = Search(earringBytes, engraving2.Reverse().ToArray());
    var engraving2Quantity_byteToStart = engraving2_byteToStart + 5;
    Console.WriteLine($"Engraving Type 2: {engraving2_byteToStart}");
    Console.WriteLine($"Engraving Quantity 2: {engraving2Quantity_byteToStart}");

    var statType1_byteToStart = Search(earringBytes, statType1.Reverse().ToArray());
    var statType1Quantity_byteToStart = Search(earringBytes, statType1Quantity.Reverse().ToArray());
    Console.WriteLine($"Stat Type 1: {statType1_byteToStart}");
    Console.WriteLine($"Stat Quantity 1: {statType1Quantity_byteToStart}");

    var negativeEngravingType_byteToStart = Search(earringBytes, negativeEngravingType.Reverse().ToArray());
    var negativeEngravingQuantity_byteToStart = negativeEngravingType_byteToStart + 9;
    Console.WriteLine($"Neg Engraving Type: {negativeEngravingType_byteToStart}");
    Console.WriteLine($"Neg Engraving Quantity: {negativeEngravingQuantity_byteToStart}");

    var itemId_byteToStart = Search(earringBytes, itemId.Reverse().ToArray());
    Console.WriteLine($"Item ID: {itemId_byteToStart}");
}

byte[] RemoveFromByteArray(byte[] src, int amountToDelete)
{
    byte[] dst = new byte[src.Length - amountToDelete];

    Array.Copy(src, amountToDelete, dst, 0, dst.Length);

    return dst;
}

int Search(byte[] src, byte[] pattern)
{
    int maxFirstCharSlot = src.Length - pattern.Length + 1;
    for (int i = 0; i < maxFirstCharSlot; i++)
    {
        if (src[i] != pattern[0]) // compare only first byte
            continue;

        // found a match on first byte, now try to match rest of the pattern
        for (int j = pattern.Length - 1; j >= 1; j--)
        {
            if (src[i + j] != pattern[j]) break;
            if (j == 1) return i;
        }
    }
    return -1;
}

byte[] GetValue(int intValue)
{
    byte[] intBytes = BitConverter.GetBytes(intValue);
    Array.Reverse(intBytes);
    byte[] result = intBytes;
    return result;
}

byte[] GetValue16(Int16 intValue)
{
    byte[] intBytes = BitConverter.GetBytes(intValue);
    Array.Reverse(intBytes);
    byte[] result = intBytes;
    return result;
}

uint GetInt16Value(byte[] bytes)
{
    Array.Reverse(bytes);
    uint intValue = BitConverter.ToUInt16(bytes, 0);
    return intValue;
}

uint GetInt32Value(byte[] bytes)
{
    Array.Reverse(bytes);
    uint intValue = BitConverter.ToUInt32(bytes, 0);
    return intValue;
}

long GetInt64Value(byte[] bytes)
{
    Array.Reverse(bytes);
    long intValue = BitConverter.ToInt64(bytes, 0);
    return intValue;
}

byte[] GetNecklaceData()
{
    return new byte[] { 0, 0, 0, 0, 20, 50, 5, 0, 1, 0, 0, 0, 1, 0, 168, 97, 0, 0, 0, 0, 0, 0, 226, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 94, 244, 242, 3, 0, 0, 0, 22, 62, 179, 182, 12, 0, 0, 28, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 31, 24, 108, 23, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 1, 0, 0, 0, 110, 0, 0, 0, 16, 0, 0, 0, 2, 244, 1, 0, 0, 244, 1, 0, 0, 144, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 110, 0, 0, 0, 15, 0, 0, 0, 2, 244, 1, 0, 0, 219, 1, 0, 0, 144, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 105, 0, 0, 0, 32, 3, 0, 0, 3, 3, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 3, 3, 0, 0, 1, 0, 0, 0, 105, 0, 0, 0, 43, 1, 0, 0, 3, 5, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 2, 3, 0, 0, 1, 0, 0, 0, 105, 0, 0, 0, 41, 1, 0, 0, 3, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 230, 119, 157, 10, 199, 241, 0, 0, 0, 248, 235, 1, 0, 0, 0, 0, 0, 184, 136, 0, 0, 0, 0, 0, 0, 1, 245, 253, 42, 5, 0, 0, 0, 0, 168, 97, 0, 0, 0, 0, 0, 0, 0 };
}

byte[] GetEarringData()
{
    return new byte[] { 50, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 56, 232, 144, 3, 0, 0, 32, 26, 73, 179, 182, 12, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 31, 24, 108, 23, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, 54, 1, 0, 0, 18, 0, 0, 0, 2, 44, 1, 0, 0, 39, 1, 0, 0, 240, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 105, 0, 0, 0, 35, 3, 0, 0, 3, 3, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 3, 3, 0, 0, 1, 0, 0, 0, 105, 0, 0, 0, 42, 1, 0, 0, 3, 5, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 2, 3, 0, 0, 1, 0, 0, 0, 105, 0, 0, 0, 41, 1, 0, 0, 3, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 230, 135, 1, 134, 230, 244, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 1, 210, 232, 63, 5, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0 };
}
