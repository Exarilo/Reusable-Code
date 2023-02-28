import discord
import json

with open('F://response.json', 'r') as f:
    messages = json.load(f)

client = discord.Webhook.from_url('webhookurl', adapter=discord.RequestsWebhookAdapter())

for message in reversed(messages):
    try:
        avatar_url = f"https://cdn.discordapp.com/avatars/{message['author']['id']}/{message['author']['avatar']}.png"
        if avatar_url:
            if not avatar_url.startswith('http'):
                avatar_url = 'https://cdn.discordapp.com/embed/avatars/0.png'
        else:
            avatar_url = 'https://cdn.discordapp.com/embed/avatars/0.png'
    
        if message.get('embeds'):
            for embed in message['embeds']:
                embed_obj = discord.Embed.from_dict(embed)
                client.send(embed=embed_obj, username=message['author']['username'], avatar_url=avatar_url)
        elif message.get('attachments'):
            for attachment in message['attachments']:
                client.send(f"{attachment['url']}", username=message['author']['username'], avatar_url=avatar_url)
        else:
            client.send(message['content'], username=message['author']['username'], avatar_url=avatar_url)
    except Exception as e:
        print(f"Error occurred while sending message {message['id']}: {e}")
        continue
