public class ParkingSystem {

    private int _big;
    private int _medium;
    private int _small;

    public ParkingSystem(int big, int medium, int small) {
        _big = big;
        _medium = medium;
        _small = small;
    }
    
    public bool AddCar(int carType) {
        if (carType == 1) {
            _big--;
            return _big >= 0;
        }
        if (carType == 2) {
            _medium--;
            return _medium >= 0;
        }
        if (carType == 3) {
            _small--;
            return _small >= 0;
        }

        return true;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */