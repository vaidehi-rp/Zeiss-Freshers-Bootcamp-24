from abc import ABC, abstractmethod

class Car(ABC):
    def __init__(self, engine, transmission):
        self.engine = engine
        self.transmission = transmission

    @abstractmethod
    def AbstractCarMethod(self):
        pass

class Engine(ABC):
    @abstractmethod
    def AbstractEngineMethod(self):
        pass
    
class AbstractEngine(Engine):
    def __init__(self, fuel_pump, startup_motor):
        self.fuel_pump = fuel_pump
        self.startup_motor = startup_motor

    @abstractmethod
    def AbstractEngineMethod(self):
        pass
        
class FuelPump(ABC):
    @abstractmethod
    def pump_fuel(self):
        pass

class StartupMotor(ABC):
    @abstractmethod
    def startUp(self):
        pass

class Transmission(ABC):
    @abstractmethod
    def transmit(self):
        pass

class MainEngine(AbstractEngine):
    def AbstractEngineMethod(self):
        pass 

class MainFuelPump(FuelPump):
    def pump_fuel(self):
        pass  

class MainStartupMotor(StartupMotor):
    def startUp(self):
        pass  

class MainTransmission(Transmission):
    def transmit(self):
        pass  

class MainCar(Car, AbstractEngine):
    def AbstractCarMethod(self):
        pass

    def AbstractEngineMethod(self):
        pass
    
engine = MainEngine(MainFuelPump(), MainStartupMotor())
transmission = MainTransmission()

car = MainCar(engine, transmission)

car.AbstractCarMethod()
#dont create object yourself, must be done through container
