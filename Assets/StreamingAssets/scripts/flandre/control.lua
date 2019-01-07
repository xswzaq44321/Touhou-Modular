local delay = 0
local a = 0
local way = 1

-- local radiate, laser, radiate2, laser2, shoot, moveRight, moveLeft, laser3

function boss.upDate()
	delay = delay + timer.deltaTime
	-- radiate();
end

function radiate()
	if (delay > 3) then
		if (delay > 3.5) then
			delay = 0
			a = 0
		end
		a = a + 0.5
		boss.radiate("pink_load", "pink_circle_small", 1, 4.4, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.0, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.6, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 6.2, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 4.4, -a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.0, -a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.6, -a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 6.2, -a * 11, 2 - a * 0.01)

		if (a < 50) then
			boss.radiate("cyan_load", "cyan_seed", 1, 1.4, a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.0, a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.6, a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 3.2, a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 1.4, -a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.0, -a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.6, -a * 11 + 180, 1.5 - a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 3.2, -a * 11 + 180, 1.5 - a * 0.02)
		end
	end
end

function laser()
	if (delay >= 0.2) then
		local x, y, z = boss.my_position()
		boss.laser("red_laser", x, y, z, boss.player_direction() + math.random(-15, 15), 1)
		delay = 0
	end
end

function radiate2()
	if (delay >= 0.015) then
		a = a + 1
		local b = a
		if (b > 15) then
			b = 15
		end
		boss.radiate("yellow_load", "yellow_circle_small", 12, 2 + b * 0.1, a * 35, 5 - a * 0.05)
		delay = 0
	end
end

function laser2()
	local x, y, z = boss.my_position()
	way = way + 180
	boss.move_straight(way, 5, 2)
	boss.laser("blue_laser", x, y, z, -60, 3, 315, 300)
	boss.laser("blue_laser", x, y, z, 240, 3, 315, -300)
end

function shoot()
	local col = {"red", "yellow", "blue", "green", "pink", "white"}
	local ccc = math.random(0, 6) + 1
	if (delay >= 0.5) then
		for i = 0, 2 do
			local x, y, z = boss.my_position()
			boss.shoot(col[ccc] .. "_load", col[ccc] .. "_seed", math.random(-7, 5.0), y + 1, 7, -90)
		end
	end
end

function moveRight()
	boss.move_straight(0, 1, 3)
end

function moveLeft()
	boss.move_straight(180, 1, 3)
end

function laser3()
	for i = 0, 2 do
		local x, y, z = boss.my_position()
		boss.laser("green_laser", x + 1 * 2, y - 1 * 3, z, 0 + 180 * i, 1, 180, -30)
		boss.laser("green_laser", x - 1 * 2, y - 1 * 6, z, 90 + 180 * i, 1, 180, -30)
	end
end
