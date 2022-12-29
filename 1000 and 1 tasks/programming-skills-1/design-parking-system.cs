public class ParkingSystem {

    private int[] _table = new int[3];

    public ParkingSystem(int big, int medium, int small) {
        _table[0] = big;
        _table[1] = medium;
        _table[2] = small;
    }
    
    public bool AddCar(int carType) {
        if (_table[carType - 1] == 0) {
            return false;
        }
        _table[carType - 1]--;
        return true;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */