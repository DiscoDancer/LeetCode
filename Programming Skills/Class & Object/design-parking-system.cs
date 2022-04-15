public class ParkingSystem {
    
    private  int _big = 0;
    private  int _medium = 0;
    private  int _small = 0;

    public ParkingSystem(int big, int medium, int small) {
        _big = big;
        _medium = medium;
        _small = small;
    }
    
    public bool AddCar(int carType) {
        if (carType == 1) {
            if (_big > 0) {
                _big--;
                return true;
            }
            return false;
        }
        
        if (carType == 2) {
            if (_medium > 0) {
                _medium--;
                return true;
            }
            return false;
        }
        
        if (carType == 3) {
            if (_small > 0) {
                _small--;
                return true;
            }
            return false;
        }
        
        return false;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */