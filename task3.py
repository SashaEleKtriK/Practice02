import math

d1 = float(input('Shortest way to water (yards): '))
d2 = float(input('Shortest way on the water to a drowning man (foots): '))
h = float(input('Lateral displacement from drowning man to savior (yards): '))
sand_speed = float(input('Moving speed on sand (miles/hour): '))
water_coefficient = float(input('Moving speed coefficient in water (n): '))
foot_to_mile = 0.000189394
yard_to_mile = 0.000568182
to_miles_per_second = 1 / 3600
d1 = d1 * yard_to_mile
d2 = d2 * foot_to_mile
h = h * yard_to_mile
sand_speed = sand_speed * to_miles_per_second
times = []
for theta in range(0, 90):
    dict = {}
    radian_angle = theta * math.pi / 180
    x = (math.tan(radian_angle) * d1)  # displacement on ground
    l_sand = ((x ** 2) + d1 ** 2) ** (1 / 2)
    l_water = (((h - x) ** 2) + d2 ** 2) ** (1 / 2)
    time_on_ground = l_sand / sand_speed
    time_in_water = l_water * water_coefficient / sand_speed
    result_time = time_on_ground + time_in_water
    dict['time'] = result_time
    dict['theta'] = theta
    times.append(dict)

best_time = {}
for time_dict in range(1, len(times) - 1):

    if times[time_dict - 1]['time'] < times[time_dict]['time'] < times[time_dict + 1]['time']:
        best_time = times[time_dict]
        break

print(f'Лучшее время {best_time["time"]}, угол {best_time["theta"]}')
