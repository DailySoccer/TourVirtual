//
//  MDPFanContactModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFanContactModel.h"


#pragma mark - Interface
@interface MDPFanContactModel : _MDPFanContactModel

+ (MDPFanContactModel *)fanContactWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanContactWithDictionary:(NSDictionary *)dictionary idUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context;

@end
