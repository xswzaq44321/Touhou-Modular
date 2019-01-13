boss.upDate = function()
	local percent = boss.getHP() / boss.getMaxHP()
	if (percent >= 0.9) then
		if (boss.delay > 3) then
			radiate(boss)
			if (boss.delay > 5) then
				boss.delay = 0
				boss.a = 0
			end
		end
	elseif (percent < 0.9 and percent >= 0.8) then
		if (boss.delay >= 0.5) then
			laser(boss)
			boss.delay = 0
		end
	elseif (percent < 0.8 and percent >= 0.7) then
		if (boss.delay >= 3) then
			radiate2(boss)
			if (boss.delay > 4) then
				boss.delay = 0
				boss.a = 0
			end
		end
	elseif (percent < 0.7 and percent >= 0.6) then
		if (boss.delay >= 4) then
			laser2(boss)
			boss.delay = 0
		end
	elseif (percent < 0.6 and percent >= 0.5) then
		if (math.floor(boss.delay / timer.deltaTime) % 2 == 1) then
			shoot(boss)
		end
		if (boss.delay >= 1) then
			if (math.random(0, 1) == 0) then
				moveRight(boss)
			else
				moveLeft(boss)
			end
			boss.delay = 0
			boss.a = 0
		end
	elseif (percent < 0.5 and percent >= 0.4) then
		if (boss.delay >= 10) then
			laser3(boss)
			boss.delay = 0
		end
	elseif (percent < 0.4 and percent >= 0.3) then
		shoot(boss)
		if (boss.delay >= 3.5) then
			radiate2(boss)
			if (boss.delay >= 4) then
				boss.delay = 0
			end
		end
	elseif (percent < 0.3 and percent >= 0.2) then
		if (boss.delay >= 3) then
			radiate3(boss)
			if (boss.delay > 3.5) then
				boss.delay = 0
				boss.a = 0
			end
		end
	else
		if (boss.delay >= 3) then
			if (boss.tempState == 0) then
				radiate(boss)
			else
				radiate2(boss)
			end
			if (boss.delay >= 3.5) then
				boss.delay = 0
				boss.a = 0
				boss.tempState = 1 - boss.tempState
			end
		end
	end
end

radiate = function(tabl)
	tabl.a = tabl.a + 6 / 11
	local err = 2
	tabl.radiate("pink_load", "pink_circle_small", 1, 4.4, tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 5.0, tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 5.6, tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 6.2, tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 4.4, -tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 5.0, -tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 5.6, -tabl.a * 11, 2 - tabl.a * 0.01)
	tabl.radiate("pink_load", "pink_circle_small", 1, 6.2, -tabl.a * 11, 2 - tabl.a * 0.01)

	if (tabl.a < 17) then
		tabl.radiate("cyan_load", "cyan_seed", 1, 1.4, tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 2.0, tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 2.6, tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 3.2, tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 1.4, -tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 2.0, -tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 2.6, -tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
		tabl.radiate("cyan_load", "cyan_seed", 1, 3.2, -tabl.a * 11 + 180 + err, 1.5 - tabl.a * 0.02)
	end
end

laser = function(tabl)
	local x, y, z = tabl.my_position()
	tabl.laser("red_laser", x, y, z, tabl.player_direction() + math.random(-15, 15), 1)
end

radiate2 = function(tabl)
	boss.a = boss.a + 1
	local b = tabl.a
	if (b > 15) then
		b = 15
	end
	tabl.radiate("yellow_load", "yellow_circle_small", 12, 2 + b * 0.1, tabl.a * 34.97, 5 - tabl.a * 0.05)
end

radiate3 = function(tabl)
	boss.a = boss.a + 1
	local b = tabl.a
	if (b > 15) then
		b = 15
	end
	tabl.radiate("blue_load", "blue_circle_small", 12, 2 + b * 0.1, tabl.a * 34.97, -5 + tabl.a * 0.05)
end

laser2 = function(tabl)
	local x, y, z = tabl.my_position()
	tabl.way = tabl.way + 180
	tabl.move_straight(tabl.way, 5, 2)
	tabl.laser("blue_laser", x, y, z, -60, 3, 315, 300)
	tabl.laser("blue_laser", x, y, z, 240, 3, 315, -300)
end

shoot = function(tabl)
	local col = {"red", "yellow", "blue", "green", "pink", "white"}
	local ccc = math.random(0, 5) + 1
	tabl.b = tabl.b + 0.1
	if (tabl.b >= 0.3) then
		tabl.b = -0.3
	end
	for i = 0, 2 do
		local x, y, z = tabl.my_position()
		tabl.shoot(col[ccc] .. "_load", col[ccc] .. "_seed", math.random(-7, 5.0) + tabl.b, y + 1, 7, -90)
	end
end

moveRight = function(tabl)
	tabl.move_straight(0, 1, 3)
end

moveLeft = function(tabl)
	tabl.move_straight(180, 1, 3)
end

laser3 = function(tabl)
	for i = 0, 2 do
		local x, y, z = tabl.my_position()
		tabl.laser("green_laser", x + 1 * 2, y - 1 * 3, z, 0 + 180 * i, 1, 180, -30)
		tabl.laser("green_laser", x - 1 * 2, y - 1 * 6, z, 90 + 180 * i, 1, 180, -30)
	end
end
