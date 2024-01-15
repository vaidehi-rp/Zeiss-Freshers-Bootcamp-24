from abc import ABC, abstractmethod
import time

class IObserver(ABC):
    @abstractmethod
    def update(self, state):
        pass

class Thread:
    def _init_(self):
        self.id1 = ''
        self.state = ''
        self.priority = ''
        self.culture = ''
        self.observers = []

    def subscribe(self, observer):
        self.observers.append(observer)

    def unsubscribe(self, observer):
        self.observers.remove(observer)

    def notify_observers(self):
        for observer in self.observers:
            observer.update(self.state)

    def start(self):
        self.state = 'start'
        self.notify_observers()

    def abort(self):
        self.state = 'abort'
        self.notify_observers()

    def sleep(self, ms):
        self.state = 'sleep'
        time.sleep(ms / 1000)
        self.notify_observers()

    def wait(self):
        self.state = 'wait'
        self.notify_observers()

    def suspend(self):
        self.state = 'suspended'
        self.notify_observers()
        
class get_state(IObserver):
    def update(self, state):
        print(f"Logger: Thread state updated to {state}")

thread = Thread()
getState = get_state()

thread.subscribe(getState)

thread.start()
time.sleep(1)  
thread.sleep(500)
time.sleep(1)
#thread.abort()