laser = function(tabl)
	if (tabl.delay >= 0.2) then
		local x, y, z = tabl.my_position()
		tabl.laser("red_laser", x, y, z, tabl.player_direction() + math.random(-15, 15), 1)
		tabl.delay = 0
	end
end

boss.upDate = function()
	laser(boss)
end