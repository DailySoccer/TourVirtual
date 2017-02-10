//
//  MDPProfileAvatarModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPProfileAvatarModel.h"


#pragma mark - Interface
@interface MDPProfileAvatarModel : _MDPProfileAvatarModel

+ (instancetype)profileAvatarWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
