from imgurpython import ImgurClient
import praw, sys

client_id = '8ee17b899ab80c3'
client_secret = 'd8ac3f7c60fb6b0f216a6e2eb10a199356ac8c1e'
user_agent = 'Paperwallz by /u/foxneZz'
subreddit = 'wallpapers'
description = 'This image was uploaded using ' + user_agent

title = url = username = password = fromurl = None

def get_input():
    global title, url
    
    for i in range(len(sys.argv)):
        if sys.argv[i] == '-t':
            title = sys.argv[i + 1]
        elif sys.argv[i] == '-u':
            url = sys.argv[i + 1]
        elif sys.argv[i] == '-n':
            username = sys.argv[i + 1]
        elif sys.argv[i] == '-p':
            password = sys.argv[i + 1]
        elif sys.argv[i] == '-i':
            fromurl = True
    
    if title == None or url == None or username == None or password == None:
        print('Not enough arguments')
        sys.exit()

def upload():
    global title, description, url, client_id, client_secret
    
    config = {
        'title': title,
        'description': description
    }
    
    return ImgurClient(client_id, client_secret).upload_from_url(url, config = config, anon = True)

print("Uploading the image...", end = "")
image = upload()
print("   OK\nSubmitting the image...", end = "")

def submit():
    global user_agent, username, password, subreddit, title, image
    r = praw.Reddit(user_agent = user_agent)
    r.login(username, password, disable_warning = True)
    r.submit(subreddit, title + ' [' + str(image['width']) + '×' + str(image['height']) + ']', url = image['link'])

submit()
print("   OK")