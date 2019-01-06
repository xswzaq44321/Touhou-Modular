local count = 0
local a = 0

local radiate

function boss.upDate()
	radiate()
end

function radiate()
	count = count + timer.deltaTime
	if(count > 3)then
		if(count > 3.5)then
			count = 0
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

		if(a < 50)then
			boss.radiate("cyan_load", "cyan_seed", 1, 1.4, a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 2.0, a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 2.6, a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 3.2, a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 1.4, -a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 2.0, -a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 2.6, -a * 11 + 180, 1.5 - a * 0.02);
			boss.radiate("cyan_load", "cyan_seed", 1, 3.2, -a * 11 + 180, 1.5 - a * 0.02);
		end
	end
end