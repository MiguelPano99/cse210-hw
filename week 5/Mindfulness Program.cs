import time
import random
import sys

# Base Activity Class
class Activity:
    def __init__(self, name, description):
        self._name = name
        self._description = description
        self._duration = 0

    def _start_message(self):
        print(f"\n--- {self._name} ---")
        print(f"Description: {self._description}")
        while True:
            try:
                self._duration = int(input("Enter the duration of the activity in seconds: "))
                if self._duration <= 0:
                    print("Duration must be a positive number. Please try again.")
                else:
                    break
            except ValueError:
                print("Invalid input. Please enter a number for the duration.")

        print("Prepare to begin...")
        self._pause_with_animation(3)  # Pause for 3 seconds before starting

    def _end_message(self):
        print("\nGood job! You have done well.")
        self._pause_with_animation(3) # Pause for 3 seconds before ending
        print(f"You have completed the {self._name} activity for {self._duration} seconds.")
        self._pause_with_animation(3) # Pause for 3 seconds after summary

    def _pause_with_animation(self, seconds, animation_type="spinner"):
        start_time = time.time()
        while time.time() - start_time < seconds:
            if animation_type == "spinner":
                for cursor in '|/-\\':
                    sys.stdout.write(cursor)
                    sys.stdout.flush()
                    time.sleep(0.1)
                    sys.stdout.write('\b')
            elif animation_type == "countdown":
                remaining_time = int(seconds - (time.time() - start_time))
                if remaining_time >= 0:
                    sys.stdout.write(f"\rPausing... {remaining_time} ")
                    sys.stdout.flush()
                time.sleep(1)
            elif animation_type == "periods":
                sys.stdout.write(".")
                sys.stdout.flush()
                time.sleep(0.5)
            else:
                time.sleep(1) # Default pause

    def run(self):
        self._start_message()
        self._perform_activity()
        self._end_message()

    def _perform_activity(self):
        # This method will be overridden by derived classes
        pass

# Breathing Activity Class
class BreathingActivity(Activity):
    def __init__(self):
        super().__init__(
            "Breathing Activity",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
        )

    def _perform_activity(self):
        start_time = time.time()
        while time.time() - start_time < self._duration:
            print("\nBreathe in...")
            self._pause_with_animation(3, "countdown")
            if time.time() - start_time >= self._duration: # Check if duration met after "Breathe in"
                break
            print("Breathe out...")
            self._pause_with_animation(3, "countdown")

# Reflection Activity Class
class ReflectionActivity(Activity):
    def __init__(self):
        super().__init__(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        )
        self._prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ]
        self._questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ]

    def _perform_activity(self):
        print(f"\nPrompt: {random.choice(self._prompts)}")
        self._pause_with_animation(5) # Pause to let user reflect on the prompt

        start_time = time.time()
        asked_questions = []
        while time.time() - start_time < self._duration:
            available_questions = [q for q in self._questions if q not in asked_questions]
            if not available_questions: # If all questions have been asked, reset
                asked_questions = []
                available_questions = self._questions

            question = random.choice(available_questions)
            asked_questions.append(question)
            print(f"\nQuestion: {question}")
            self._pause_with_animation(5, "spinner") # Pause for reflection on the question

# Listing Activity Class
class ListingActivity(Activity):
    def __init__(self):
        super().__init__(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
        self._prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ]

    def _perform_activity(self):
        print(f"\nPrompt: {random.choice(self._prompts)}")
        print("Prepare to list items...")
        self._pause_with_animation(5, "countdown") # Give time to think before listing

        print("\nStart listing items (press Enter after each item. Press Ctrl+C or simply wait for duration to end):")
        item_count = 0
        start_time = time.time()
        while time.time() - start_time < self._duration:
            try:
                # Non-blocking input attempt (will still block in simple console, but conceptually for timed input)
                # For true non-blocking input, a more complex solution with threading or async would be needed.
                # Here, we'll let the user input until the time is up, and if they press enter on an empty line, it counts.
                sys.stdout.write(f"Item {item_count + 1}: ")
                sys.stdout.flush()
                # A simple way to simulate timed input without complex libraries:
                # Just allow input, and the loop will naturally break when time is up.
                # This means the last input might be cut short if the duration ends.
                # A more robust solution for timed input would involve advanced techniques.
                line = ""
                # This loop simulates a non-blocking read for a short period.
                # In a real scenario, this would likely involve select or threading.
                # For this console app, we'll accept basic input until the time runs out.
                while time.time() - start_time < self._duration:
                    char = sys.stdin.read(1)
                    if char == '\n':
                        break
                    line += char
                if line.strip(): # Only count if something was typed before Enter/timeout
                    item_count += 1
            except KeyboardInterrupt:
                print("\nListing interrupted.")
                break
            except Exception as e:
                print(f"An error occurred: {e}")
                break

        print(f"\nYou listed {item_count} items.")

# Main Program Loop
def main():
    while True:
        print("\n--- Mindfulness Activities Menu ---")
        print("1. Breathing Activity")
        print("2. Reflection Activity")
        print("3. Listing Activity")
        print("4. Exit")

        choice = input("Enter your choice (1-4): ")

        if choice == '1':
            activity = BreathingActivity()
        elif choice == '2':
            activity = ReflectionActivity()
        elif choice == '3':
            activity = ListingActivity()
        elif choice == '4':
            print("Exiting program. Goodbye!")
            break
        else:
            print("Invalid choice. Please enter a number between 1 and 4.")
            continue

        activity.run()

if __name__ == "__main__":
    main()