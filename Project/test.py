import pandas as pd

def calculate_fps_from_csv(file_path):
    try:
        # Load the CSV file
        data = pd.read_csv(file_path, sep=';')  # For tab-separated files

        # Strip whitespace from column names
        data.columns = data.columns.str.strip()

        # Extract the "Frame Time (ms)" column
        frame_times = data.iloc[:,2]

        # Filter out invalid values (non-numeric entries)
        frame_times = pd.to_numeric(frame_times, errors='coerce')
        frame_times = frame_times.dropna()  # Remove NaN values

        # Calculate average frame time
        average_frame_time = frame_times.mean()

        # Calculate FPS
        if average_frame_time > 0:
            average_fps = 1000 / average_frame_time
            print(f"Average Frame Time: {average_frame_time:.2f} ms")
            print(f"Average FPS: {average_fps:.2f}")
        else:
            print("Average frame time is 0, FPS cannot be calculated.")

    except FileNotFoundError:
        print(f"File not found: {file_path}")
    except KeyError:
        print("Column 'Frame Time (ms)' not found in the file.")
    except Exception as e:
        print(f"An error occurred: {e}")

# Example usage
file_path = "h14.csv"  # Replace with your actual file path
calculate_fps_from_csv(file_path)
