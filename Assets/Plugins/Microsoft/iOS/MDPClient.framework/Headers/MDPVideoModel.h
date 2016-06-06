//
//  MDPVideoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPVideoModel.h"


#pragma mark - Interface
@interface MDPVideoModel : _MDPVideoModel

+ (MDPVideoModel *)videosWithIdVideo:(NSString *)idVideo managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)videosWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)videosWithIdSeason:(NSString *)idSeason
                  idCompetition:(NSString *)idCompetition
                        idMatch:(NSString *)idMatch
           managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsVideosWithIdSeason:(NSString *)idSeason
                                      idCompetition:(NSString *)idCompetition
                                            idMatch:(NSString *)idMatch
                                         dictionary:(NSDictionary *)dictionary
                               managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsVideosWithDictionary:(NSDictionary *)dictionary
                                 managedObjectContext:(NSManagedObjectContext *)context;

- (NSArray *)videoTypesString;

@end
