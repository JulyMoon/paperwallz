from imgurpython import ImgurClient
import praw, sys

client_id = '8ee17b899ab80c3'
client_secret = 'd8ac3f7c60fb6b0f216a6e2eb10a199356ac8c1e'
user_agent = 'Paperwallz by /u/foxneZz'
subreddit = 'wallpapers'
description = 'This image was uploaded using [' + user_agent + ']'

title = url = username = password = fromurl = None

#stuffing arguments into variables
for i in range(len(sys.argv)):
    if sys.argv[i] == '-t': #title
        title = sys.argv[i + 1]
    elif sys.argv[i] == '-u': #image path/url
        url = sys.argv[i + 1]
    elif sys.argv[i] == '-n': #username
        username = sys.argv[i + 1]
    elif sys.argv[i] == '-p': #password
        password = sys.argv[i + 1]
    elif sys.argv[i] == '-i': #image source
        fromurl = True

if title == None or url == None or username == None or password == None:
    print('NOTENOUGHARGUMENTSLEL')
    sys.exit()

description += ' | Uploader: /u/' + username

#signing in
r = praw.Reddit(user_agent = user_agent)
r.login(username, password, disable_warning = True)

#uploading:
image = ImgurClient(client_id, client_secret).upload_from_url(url, config = { 'title': title, 'description': description }, anon = True)
print('WEREDONEWITHIMGURBOYS')

#submitting:
print('PEACEOUT ' + r.submit(subreddit, title + ' [' + str(image['width']) + '×' + str(image['height']) + ']', url = image['link']).permalink)