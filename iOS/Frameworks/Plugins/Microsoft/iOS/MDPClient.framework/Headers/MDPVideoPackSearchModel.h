//
//  MDPVideoPackSearchModel.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 23/8/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - Interface
@interface MDPVideoPackSearchModel : NSObject

- (instancetype)initWithSeason:(NSString *)season
                    videoTypes:(NSArray *)videoTypes
               matchEventTypes:(NSArray *)matchEventTypes
               competitionType:(NSString *)competitionType
          isExactVideoMetadata:(BOOL)isExactVideoMetadata
                    mainActors:(NSArray *)mainActors
                      language:(NSString *)language
                           top:(NSInteger)top skip:(NSInteger)skip;

- (NSString *)season;

- (NSArray *)videoTypes;

- (NSArray *)matchEventTypes;

- (NSString *)competitionType;

- (BOOL)isExactVideoMetadata;

- (NSArray *)mainActors;

- (NSString *)language;

- (NSInteger)top;

- (NSInteger)skip;

- (NSDictionary *)convertVideoPackSearchToDictionary;

@end
