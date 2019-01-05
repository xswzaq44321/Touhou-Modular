local count = 0
local a = 0

function boss.upDate()
	count = count + timer.deltaTime;
	if(count > 2)then
		if(count > 3)then
			count = 0
			a = 0
		end
		a = a + 1
		boss.radiate("pink_load", "pink_circle_small", 1, 4.4, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.0, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.6, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 6.2, a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 4.4, -a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.0, -a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.6, -a * 11, 2 - a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 6.2, -a * 11, 2 - a * 0.01)
	end
end