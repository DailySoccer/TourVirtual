//
//  MDPBodyPlatformNotificationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPBodyPlatformNotificationModel.h"


#pragma mark - Interface
@interface MDPBodyPlatformNotificationModel : _MDPBodyPlatformNotificationModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)bodyPlatformNotificationWithSet:(NSSet *)bodyPlatformNotifications language:(NSString *)language;

@end
