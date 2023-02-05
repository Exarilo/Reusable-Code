import discord

client = discord.Client()

@client.event
async def on_ready():
    print(f'Connecté en tant que {client.user}')

@client.event
async def on_message(message):
    if message.author == client.user:
        return

    if message.content.startswith('!copy'):
        await message.delete()
        source_channel = message.channel
        global copied_messages
        copied_messages = []
        async for source_message in source_channel.history(limit=None):
            copied_messages.append(source_message)
        

    if message.content.startswith('!paste'):
        await message.delete()
        destination_channel = message.channel
        if destination_channel is not None:
            for source_message in reversed(copied_messages):
                if source_message.embeds:
                    embed = source_message.embeds[0]
                    await destination_channel.send(embed=embed)
                else:
                    embed = discord.Embed(
                        description=source_message.content,
                        color=discord.Color.blue()
                    )
                    embed.set_author(
                        name=source_message.author.name,
                        icon_url=source_message.author.avatar_url
                    )
                    await destination_channel.send(embed=embed)
            

client.run('Token') 
