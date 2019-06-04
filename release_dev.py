def main():
	print("Release build finished? (y/n)")
	ans = input()
	if ans != "y":
		return
	print("Version number set in manifest? (y/n)")
	ans = input()
	if ans != "y":
		return
	print("Version number set in setup? (y/n)")
	ans = input()
	if ans != "y":
		return
	
	
	

if __name__ == "__main__":
	main()